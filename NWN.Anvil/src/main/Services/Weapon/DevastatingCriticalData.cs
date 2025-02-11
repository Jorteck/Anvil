using Anvil.API;

namespace Anvil.Services
{
  public sealed class DevastatingCriticalData
  {
    public bool Bypass { get; set; }

    public int Damage { get; set; }

    public NwGameObject Target { get; init; } = null!;
    public NwItem Weapon { get; init; } = null!;
  }
}
