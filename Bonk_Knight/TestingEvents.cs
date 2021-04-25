using System;
namespace Bonk_Knight
{
    public class TestingEvents
    {
        public event EventHandler OSP;
        public event EventHandler<person> manRobed;

        public TestingEvents()
        {
            //now testOSP will trigger when OSP does
            OSP += TestOSP;
            OSP += Test2OSP;
            manRobed += copsTime;
            up();
        }

        public void TestOSP(object sender,  EventArgs e /*makes sure to change if custom*/)
        {
            Console.WriteLine("ya");
            Console.ReadKey();

        }
        public void Test2OSP(object sender, EventArgs e)
        {
            Console.WriteLine("we got it");
            person Robby = new person();
            Robby.Name = "big R";
            Robby.ballence = 100;
            manRobed?.Invoke(this, Robby); 
        }

        public void copsTime(object sender, person inno)
        {
            Console.WriteLine($"{inno.Name} was robbed for {inno.ballence}");
            Console.WriteLine($"Cops Get him!!");
        }

        public void up()
        {
            // the ? checks the null event so if no-one is listening doesn't run
            OSP?.Invoke(this, EventArgs.Empty);
        }

    }

    public class person
    {
        public string Name { get; set; }
        public int ballence { get; set; }
    }
}
