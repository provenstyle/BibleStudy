using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BibleStudy.Data.Entities;

namespace BibleStudy.Data.Commands
{
    public class CreateVerse : Scalar<Verse>
    {
        private readonly Verse _verse;

        public CreateVerse(Verse verse)
        {
            _verse = verse;

            Command.CommandText = "InsertVerse";

            Parameters = new IDbDataParameter[] {
                new SqlParameter(nameof(verse.Chapter),verse.Chapter),
                new SqlParameter(nameof(verse.Number), verse.Number),
                new SqlParameter(nameof(verse.BookId), verse.BookId),
                new SqlParameter(nameof(verse.Text),   verse.Text),
                new SqlParameter(nameof(verse.Id),     ParameterDirection.Output)
            };
        }

        public override Verse Map()
        {
            _verse.Id = (int)Parameters[4].Value;
            return _verse;
        }
    }
}

public abstract class Scalar<T> where T : class
{
    public IDbCommand Command { get; set; }

    public IDbDataParameter[] Parameters
    {
        get { return Command?.Parameters.Cast<IDbDataParameter>().ToArray(); }
        set
        {
            foreach (var parameter in value)
            {
                Command.Parameters.Add(parameter);
            }
        }
    }

    public abstract T Map();
}

public class Repository
{
    private IDbConnection Connection { get; set; }

    public T Find<T>(Scalar<T> scalar) where T : class
    {
        scalar.Command.Connection = Connection;
        scalar.Command.ExecuteNonQuery();
        return scalar.Map();
    }
}

