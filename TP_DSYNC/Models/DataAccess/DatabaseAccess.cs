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

        private Database db2;
        protected Database Db2
        {
            get
            {
                if (this.db2 == null)
                {
                    this.db2 = this.factory.Create(this.ConnectionStringName);
                }
                return this.db2;
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
        private string connectionStringName2;
        protected string ConnectionStringName2
        {
            get
            {
                return connectionStringName2;
            }
            set
            {
                connectionStringName2 = value;
            }
        }

        public DatabaseAccess(string connectionStringName)
        {
            this.ConnectionStringName = connectionStringName;

        }
        public DatabaseAccess(string connectionStringName, string connectionStringName2)
        {
            this.ConnectionStringName = connectionStringName;
            this.ConnectionStringName2 = connectionStringName2;
        }

    }
}
