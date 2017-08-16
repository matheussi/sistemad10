namespace Entidade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LC.Framework.Phantom;
    using System.Data;

    [DBTable("CLI_USUARIOS")]
    public class Usuario : EntityBase, IPersisteableEntity
    {
        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
        {
            get;
            set;
        }

        [DBFieldInfo("NOME", FieldType.Single)]
        public string Nome
        {
            get;
            set;
        }

        [DBFieldInfo("ADMIN", FieldType.Single)]
        public int Admin
        {
            get;
            set;
        }

        public void Carregar()
        {
            base.Carregar(this);
        }
    }
}
