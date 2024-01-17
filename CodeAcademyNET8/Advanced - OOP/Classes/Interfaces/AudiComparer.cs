namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class AudiComparer : IComparer<AudiCar>
{
    public int Compare(AudiCar? x, AudiCar? y)
    {
        if (x == null && y == null)
            return 0;

        if (x == null)
            return -1;

        if (y == null)
            return 1;

        if (y.Model.StartsWith("RS", StringComparison.CurrentCultureIgnoreCase) &&
            x.Model.StartsWith("RS", StringComparison.CurrentCultureIgnoreCase))
            return 0;

        if (x.Model.StartsWith("RS", StringComparison.CurrentCultureIgnoreCase))
            return 1;

        if (y.Model.StartsWith("RS", StringComparison.CurrentCultureIgnoreCase))
            return -1;

        if (y.Model.StartsWith("S", StringComparison.CurrentCultureIgnoreCase) &&
            x.Model.StartsWith("S", StringComparison.CurrentCultureIgnoreCase))
            return 0;

        if (x.Model.StartsWith("S", StringComparison.CurrentCultureIgnoreCase))
            return 1;

        if (y.Model.StartsWith("S", StringComparison.CurrentCultureIgnoreCase))
            return -1;

        if (x.IsQuattro && y.IsQuattro)
            return 0;

        if (x.IsQuattro)
            return 1;

        if (y.IsQuattro)
            return -1;

        return 0;
    }
}