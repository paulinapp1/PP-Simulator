

namespace Simulator
{

    public class Animals
    {
        private string description = "Unknown";
        public required string Description
        {
            get { return description; }
            init
            {
                var trimmed = value.Trim();
                if (trimmed.Length < 3)
                {
                    trimmed = trimmed.PadRight(3, '#');
                }
                else if (trimmed.Length > 15)
                {
                    trimmed = trimmed.Substring(0, 15);
                }
                if (!char.IsUpper(trimmed[0]))
                {
                    trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1); 
                }
                trimmed = trimmed.Trim();
                if (trimmed.Length < 3)
                {
                    trimmed = trimmed.PadRight(3, '#');
                }
                description = trimmed;
            }

        }


        public uint Size { get; set; } = 3;


        public string Info
        {
            get { return $"{Description} <{Size}>"; }
        }
    }



}
