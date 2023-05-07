using _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Enums;

namespace _20230408_AsyncProgramming_CRUD.Infrastructure.Extensions.Classes
{
    public static class ExAlert
    {

        public static string Create(this string txt, AlertType type)
        {
            string format = @"<div class='alert alert-{0}'>" + txt + "</div>";
            return string.Format(format, type);
        }

    }
}
