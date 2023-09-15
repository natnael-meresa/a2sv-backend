public class Avarage
{
    public decimal CalulateAvarage(Dictionary<string, decimal> grades, Int32 count) {
        decimal totalGrade = 0.0M;

        foreach (KeyValuePair<string, decimal> item in grades)
        {
            totalGrade += item.Value;            
        }
        return totalGrade/count;
    }
}