using System;

namespace ComputerStore.Api.Services
{
    public class DtoServices
    {
        public static bool NewOrNah(DateTime date)
        {
            if (date < DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)))
            {
                return false;
            }
            return true;
        }
    }
}
