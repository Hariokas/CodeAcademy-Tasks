namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class BmwComparer : IComparer<BmwCar>
{
    public int Compare(BmwCar? x, BmwCar? y)
    {
        if (x == null && y == null)
            return 0;

        if (x == null)
            return -1;

        if (y == null)
            return 1;

        if (y.Model.StartsWith("M", StringComparison.CurrentCultureIgnoreCase) &&
            x.Model.StartsWith("M", StringComparison.CurrentCultureIgnoreCase))
            return 0;

        if (x.Model.StartsWith("M", StringComparison.CurrentCultureIgnoreCase))
            return 1;

        if (y.Model.StartsWith("M", StringComparison.CurrentCultureIgnoreCase))
            return -1;

        if (x.IsXDrive && y.IsXDrive)
            return 0;

        if (x.IsXDrive)
            return 1;

        if (y.IsXDrive)
            return -1;

        return 0;
    }
}