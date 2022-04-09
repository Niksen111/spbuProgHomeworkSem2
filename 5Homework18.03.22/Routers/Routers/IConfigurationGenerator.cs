namespace Routers;

public interface IConfigurationGenerator
{
    public void GenerateConfig(string path);
    
    public void PrintConfigToFile(string path);

    public int SumOfCapacities { get; }
}