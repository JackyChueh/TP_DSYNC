using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TP_DSYNC.Models.DataAccess
{
    public abstract class B3BUFFER_DSCCR_Access
    {

        private DatabaseProviderFactory factory = new DatabaseProviderFactory();

        private Database dbB3BUFFER;
        protected Database DbB3BUFFER
        {
            get
            {
                if (this.dbB3BUFFER == null)
                {
                    this.dbB3BUFFER = this.factory.Create(this.connectionStringNameB3BUFFER);
                }
                return this.dbB3BUFFER;
            }
        }

        private Database dbDSCCR;
        protected Database DbDSCCR
        {
            get
            {
                if (this.dbDSCCR == null)
                {
                    this.dbDSCCR = this.factory.Create(this.ConnectionStringNameDSCCR);
                }
                return this.dbDSCCR;
            }
        }

        private string connectionStringNameB3BUFFER;
        protected string ConnectionStringNameB3BUFFER
        {
            get
            {
                return connectionStringNameB3BUFFER;
            }
            set
            {
                connectionStringNameB3BUFFER = value;
            }
        }
        private string connectionStringNameDSCCR;
        protected string ConnectionStringNameDSCCR
        {
            get
            {
                return connectionStringNameDSCCR;
            }
            set
            {
                connectionStringNameDSCCR = value;
            }
        }

        public B3BUFFER_DSCCR_Access(string ConnectionStringNameB3BUFFER)
        {
            this.connectionStringNameB3BUFFER = ConnectionStringNameB3BUFFER;

        }
        public B3BUFFER_DSCCR_Access(string ConnectionStringNameB3BUFFER, string ConnectionStringNameDSCCR)
        {
            this.connectionStringNameB3BUFFER = ConnectionStringNameB3BUFFER;
            this.connectionStringNameDSCCR = ConnectionStringNameDSCCR;
        }

    }
}
