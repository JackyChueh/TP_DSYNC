using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TP_DSYNC.Models.DataAccess
{
    public abstract class DatabaseAccess
    {

        private DatabaseProviderFactory factory = new DatabaseProviderFactory();

        private Database db;
        protected Database Db
        {
            get
            {
                if (this.db == null)
                {
                    this.db = this.factory.Create(this.ConnectionStringName);
                }
                return this.db;
            }
        }

        private string connectionStringName;
        protected string ConnectionStringName
        {
            get
            {
                return connectionStringName;
            }
            set
            {
                connectionStringName = value;
            }
        }

        public DatabaseAccess(string connectionStringName)
        {
            this.ConnectionStringName = connectionStringName;
        }

    }
}
