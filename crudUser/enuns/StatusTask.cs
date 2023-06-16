using System.ComponentModel;

namespace crudUser.Enums
{
    public enum StatusTask
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluído = 3
    }
}