﻿using System.ComponentModel;

namespace MinhaAPI.Enus
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluído = 3
    }
}
