namespace App.API
{
    public class VarianService
    {
        public string HelloVarianEmployee(string secretName)
        {
            // We might have some more sophisticated calculations or DB interaction
            return $"Hello from this amazing service, how are you {secretName}?";
        }
    }
}
