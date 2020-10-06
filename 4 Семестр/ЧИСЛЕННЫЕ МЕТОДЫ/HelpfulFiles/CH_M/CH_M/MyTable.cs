namespace CH_M
{
    internal class MyTable
    {
        public MyTable(int i, double x, double y, string accuracy)
        {
            this.i = i;
            this.x = x;
            this.y = y;
            this.accuracy = accuracy;
           // this.F = F;
        }
        public double i { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public string accuracy { get; set; }
     //   public double F { get; set; }
    }
}