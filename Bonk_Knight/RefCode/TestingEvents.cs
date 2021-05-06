using System;
using System.Threading;
namespace Bonk_Knight
{
    public class TestingEvents /* : EventArgs  <- not nessisary*/
    {
        public event EventHandler OSP;
        public event EventHandler<person> manRobed;

        /*###############
        general important stuff about events
        1.remove listner from event before destroying class instance
             ->  -=   e.g. <event> -= <func>
             -> do it on close
        2.
        */

        public TestingEvents()
        {
            //now testOSP will trigger when OSP does
            OSP += Test2OSP;
            manRobed += copsTime;
            up();
        }

        public void Test2OSP(object sender, EventArgs e)
        {
            Console.WriteLine("we got it");

            //pressing a key before will stop the animation already
            //----------- clear console Input first??-----------------------???
            Thread.Sleep(100);

            //making an event with more info passed in
            //person Robby = new person("big R", 100);
            //manRobed?.Invoke(this, Robby); 
        }

        public void copsTime(object sender, person inno)
        {
            //using extra info passed in through args
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
        public string Name { get; private set; }
        public int ballence { get; private set; }
        //use private sets and passing in func
        public person(string nam, int blnce)
        {
            Name = nam;
            ballence = blnce;
        }
        // keeps it mostly constant as first event can't change it for the others


        //public ->  can use it for canceling thing mid way
        public bool cancel { get; set; } = false;
        public bool ContinueYN { get; set; } = true;


    }
}
