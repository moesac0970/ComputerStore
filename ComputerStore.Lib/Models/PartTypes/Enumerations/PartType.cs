namespace ComputerStore.Lib.Models.PartTypes.Enumerations
{
    /// <summary>
    /// when naming new parttypes follow this naming convention
    /// controller => type+s (ex: cpu => cpus, gpu => gpus)
    /// </summary>
    public enum PartType
    {
        Cpu,
        Gpu,
        Memory,
        MotherBoard,
        PcCase
    }
}
