﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using System.Threading;
using System.Diagnostics;
using System.Text;

namespace UITest10
{
    [TestFixture]
    public class RandomGenerator
    {

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }



    public class Tests
    {
        public static string final_email;
        RandomGenerator generator = new RandomGenerator();
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile ("../../../Android/bin/Debug/app-us-uat.apk")
                .StartApp();
        }

        [Test]
        public void a_Register()
        {
           //app.Repl();

             string str = generator.RandomString(10, false);
            int rand = generator.RandomNumber(5, 100);
            string randomnumber = rand.ToString();
            string email = String.Concat(str, randomnumber);
            string remain = "@pampers.com";
            final_email = String.Concat(email, remain);
            Thread.Sleep(25000);
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.Tap(x => x.Id("joinNowButton"));
            Thread.Sleep(7000);
            app.Tap(x => x.Id("firstNameEditText"));
            app.EnterText("Arshad");
            //needs to be changed to the calender element
            app.ScrollDownTo(x => x.Id("firstNameEditText"), strategy: ScrollStrategy.Auto);
            Thread.Sleep(3000);
            app.Tap("Child's Birth / Due Date");
            app.Query(c => c.Class("AlertDialogLayout"));
            app.Tap("OK");
            app.ScrollDownTo("Email", strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("Email");
            app.Tap("Email");
            app.EnterText(final_email);
            app.Tap("ZIP Code");
            app.EnterText("34265");
            app.ScrollDown("Password");
            app.Tap("Password");
            app.EnterText("magicA123");
            app.ScrollDownTo("I'd love to join!", strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("I'd love to join!");
            app.Query(c => c.Marked("OK").Parent().Class("AlertDialogLayout"));
           // b_ProfileUpdate();
            //i_anotherchild();
            //c_pamper_reward();
            d_reg_logout();
            //f_MyDetails();
            //e_menubar();
            //g_changepassword();
        }

        [Test]
        public void login() {

            Thread.Sleep(20000);
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.Tap(x => x.Id("alreadyHaveAccountButton"));
            app.Tap("Email");
            app.EnterText(final_email);
            app.Tap("Password");
            app.EnterText("magicA123");
            app.ScrollDownTo("Sign me in!", strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap(x => x.Id("signInButton"));
            Thread.Sleep(10000);
            b_ProfileUpdate();
            i_anotherchild();
            c_pamper_reward();
            e_menubar();
            f_MyDetails();
            g_changepassword();
            home_ParentsHub();
        }


        public void i_anotherchild() {

            Thread.Sleep(25000);
            app.Tap("I've had another baby");
            app.Tap("Child's First Name");
            app.EnterText("Aleesha");
            app.Tap("Child's Birth / Due Date");
            app.Tap("Next month");
            app.Tap(x => x.Id("date_picker_day_picker"));
            app.Tap("OK");
            app.Tap("Save");
            Thread.Sleep(10000);
            // app.Visibility("Edit");
            app.WaitForElement("Edit");


        }
        public void e_menubar()
        {

            Thread.Sleep(15000);
            app.Tap(x => x.Id("imgBack"));
            app.Tap(x => x.Id("imgBack"));
            app.Tap(x => x.Id("action_hamburger"));
            Thread.Sleep(10000);
            string data = app.Query(c => c.Id("navItemText"))[0].Text;
            string data1 = app.Query(c => c.Id("navItemText"))[1].Text;
            string data2 = app.Query(c => c.Id("navItemText"))[2].Text;
            bool result = data.Equals("Pampers account");
            bool result1 = data1.Equals("History");
            bool result2 = data2.Equals("Help");
            result.Equals(result1.Equals(result2));
            Console.WriteLine(data);
            Console.WriteLine(data1);
            Console.WriteLine(data2);
            //app.Equals(data);


        }

        public void b_ProfileUpdate()
        {

            Thread.Sleep(15000);
            app.Tap(x => x.Id("action_hamburger"));
            Thread.Sleep(10000);
            app.Tap("Pampers account");

            //app.Qnuery(c => c.Marked("Pampers Account").Parent().Class("AlertDialogLayout"));
            app.Tap("My Baby");
            app.Tap("Edit");
            app.Tap("Child's First Name");
            //app.Query(c => c.Marked("Male").Parent().Class("AlertDialogLayout"));
            //app.Tap("First Name");
            app.EnterText("Baby Name");
            app.Tap("My baby's birthday");
            //app.Tap("Khan");
            //app.Tap("Birthday");
            app.Query(c => c.Marked("OK").Parent().Class("AlertDialogLayout"));
            app.Tap("OK");
            app.DismissKeyboard();
            app.Tap("Save");



        }
        public void f_MyDetails()
        {

            //Thread.Sleep(15000);
            //app.Tap(x => x.Id("action_hamburger"));
            //Thread.Sleep(10000);
            app.Tap("Pampers account");
            app.Tap(x => x.Id("imgBack"));
            app.Tap("My Details");
            app.Tap("Edit");
            app.Tap("Gender");
            app.Tap("Male");
            app.Tap("Last Name");
            app.EnterText("Ahsan");
            app.Tap("Birthday");
            app.Tap(x => x.Id("date_picker_header_year"));
            app.Tap("1997");
            app.Tap("OK");
            app.ScrollDownTo(x => x.Id("saveButton"), strategy: ScrollStrategy.Auto);
            app.Tap(x => x.Id("saveButton"));
            Thread.Sleep(10000);
            // app.Visibility("Edit");
            app.WaitForElement("Edit");




        }



        public void c_pamper_reward()
        {

            Thread.Sleep(15000);
            app.Tap(x => x.Id("action_home"));


            app.Tap("Featured Rewards");
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.Tap("See Rewards Here");
            app.Tap(x => x.Id("action_reward"));
            Thread.Sleep(10000);
            app.Tap("Shutterfly Prints Package");
            Thread.Sleep(10000);
            app.Tap(x => x.Id("rewardRedeemNowButton"));
            app.ScrollDownTo("Great! Place my order", strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            //app.Tap(x => x.Id("placeOrderButton"));



        }

        public void d_logout()
        {

            Thread.Sleep(15000);
            app.Tap(x => x.Id("imgBack"));
            app.Tap(x => x.Id("imgBack"));
            ////id for below
            app.Tap(x => x.Id("action_hamburger"));
            //app.Tap(x => x.Id("navAccountItem"));
            app.Tap("Pampers account");
           // app.Tap(x => x.Id("imgBack"));
            app.ScrollDownTo("Let's sign out", strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));

            app.Tap(x => x.Id("logOutText"));

        }

        public void d_reg_logout()
        {

            Thread.Sleep(15000);
            
            app.Tap(x => x.Id("action_hamburger"));
            //app.Tap(x => x.Id("navAccountItem"));
            app.Tap("Pampers account");
           // app.Tap(x => x.Id("imgBack"));
            app.ScrollDownTo("Let's sign out", strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));

            app.Tap(x => x.Id("logOutText"));

        }
        public void g_changepassword()
        {

            //Thread.Sleep(15000);
           // app.Tap(x => x.Id("action_hamburger"));
            //Thread.Sleep(10000);
           // app.Tap("Pampers account");
            app.Tap("Change my password");
            app.Tap("Close");


        }
        public void home_ParentsHub()
        {
            Thread.Sleep(15000);
            app.Tap(x => x.Id("action_home"));
            app.Tap("Parents' Hub");
            app.SwipeRightToLeft(); 
            app.SwipeRightToLeft(); 
            app.SwipeRightToLeft(); 
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.Tap(x => x.Id("imgBack"));
        }
        
        public void home_GetMorePoints()
        {
            app.Tap("Get More Points");
            app.Tap("Scan Code Now");
            app.Tap(x => x.Id("diaperImageView"));
            app.Tap("Diapers or Easy Ups bag");
            app.Tap("Diapers or Easy Ups bag");
            app.Tap("Diapers or Easy Ups box");
            app.Tap("Diapers or Easy Ups box");
            app.Tap(x => x.Id("gotItButton"));
            app.Tap(x => x.Id("manualEntryImageView"));
            app.Tap(x => x.Id("textInputEditText"));
            app.EnterText("RNT94K3FHXWJ74");
            app.Tap(x => x.Id("submitCodeButton"));
            app.EnterText("XTR3CWHJ347TWC");
            app.EnterText("XTR3CWHJ347TWC");
            app.Tap(x => x.Id("submitCodeButton"));
            app.Flash(x => x.Id("scanAnotherCodeButton"));
            app.Tap(x => x.Id("wantAnotherButton"));
            app.Tap(x => x.Id("helpImageView"));
            app.Tap(x => x.Id("helpImageView"));
            app.Tap("Got a wipes tub?");
            app.Tap("Got a wipes tub?");
            app.Tap("Got a wipes refill pack?");
            app.Tap("Got a wipes refill pack?");
            app.Tap(x => x.Id("gotItButton"));
            app.Tap(x => x.Id("closeImageView"));
        }
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }
    }
}

