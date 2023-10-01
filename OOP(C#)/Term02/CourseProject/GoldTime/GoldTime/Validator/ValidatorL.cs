using System.Text.RegularExpressions;

namespace Validator
{
    public static class ValidatorL
    {
        public static bool Validate(string str, string type)
        {
            switch(type)
            {
                case "Email":
                    {
                        Regex regex = new Regex("^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;]{0,1}\\s*)+$");
                        return regex.IsMatch(str);
                    }
                default:
                    return false;
            }
            

            return false;
        }
    }
}