﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SadCL
{
    class Program
    {
        //This enum isn't being used by anything.
        //enum hardVar{
        //    vertMaxtick = 700,
        //    horizonMaxtick = 6000,
        //    vertMaxAngle = 45,
        //    horizonMaxAngle = 270
        //}
        static void Main(string[] args) {



            // // Various setup stuff
            Target.TargetManager tMan = Target.TargetManager.Instance;
            bool doneFlag = false;
            string inLine, givenAct, givenMod; // Input-line, given-action, given-modifier

            MissileLauncher.MissileLauncherController mMan = new MissileLauncher.MissileLauncherController();
            //MissileLauncher.MissileLauncherController mMan = MissileLauncher.MissileLauncherController.Instance;

            //Should reset the turret before we even begin.
			mMan.reset();

            // // Print that we're actually ready to go!
            Console.WriteLine("Status: OPERATIONAL");
            Console.WriteLine("Gimme somethin' t' shoot!");

            while (!doneFlag) {

                // Get the line and do some string transforms
                System.Console.Write("> ");
                inLine = Console.ReadLine();

                givenAct = inLine.Split(' ')[0].ToLower();

                // We have get the modifier in this way because the line may contain many spaces. This way we go from the first space till the end of the line and set that to be our modifier
                if (inLine.Split(' ').Length > 1 ) 
                    givenMod = inLine.Substring(inLine.IndexOf(' ')+1); // '+1' is so we don't include the space in the string we get
                else 
                    givenMod = "";
                
                // Giant hairy if-elseif statement
                if (givenAct == "load"){

                    if (File.Exists(givenMod)){
                        tMan.load(givenMod);
                        Console.WriteLine("File has been shifted into MAXIMUM OVERDRIVE!!!");
                    }
                    else
                        Console.WriteLine("File specified doesn't exist.");

                } else if (givenAct == "scoundrels") {
                    tMan.printEnemies();
                } else if (givenAct == "friends") {
                    tMan.printFriends();
                } else if (givenAct == "kill") {

                    double X = 0.0;
                    double Y = 0.0;
                    double Z = 0.0;

                    Tuple<double, double, double> targCoords = tMan.takeAim(givenMod);

                    if (targCoords != null) {
                        X = targCoords.Item1;
                        Y = targCoords.Item2;
                        Z = targCoords.Item3;
                        double r = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
                        double Theta = (Math.PI / 2) - Math.Acos(Z / r);
                        double Phi = Math.Atan2(Y, X);

                        // Uses non-relative tick conversion
                        Phi = CoordConvert.sphToTick(Phi);
                        Theta = CoordConvert.vertSphToTick(Theta);

                        mMan.move(Phi, Theta);
                        mMan.fire();
                    }

                } else if (givenAct == "fire") {
                    mMan.fire();
                } else if (givenAct == "exit") { // Peace yo, we out
                    doneFlag = true;
                } else if (givenAct == "moveby") {

					double Phi = 0.0, Theta = 0.0;

                    //Will return either a list of 2 or list of 0.
                    List<double> input = CoordConvert.getPhiTheta(givenMod);

                    if (input.Count == 2) {
                        Phi = input[0];
                        Theta = input[1];

                        // uses relative tick-conversion for naive rotation
                        Phi = CoordConvert.sphToTickRel(Phi);
                        Theta = CoordConvert.vertSphToTick(Theta);

                        mMan.moveBy(Phi, Theta);
                    }
					

				} else if (givenAct == "move") {
					
					double Phi = 0.0, Theta = 0.0;

                    //Will return either a list of 2 or list of 0.
                    List<double> input = CoordConvert.getPhiTheta(givenMod);

                    if (input.Count == 2) {
                        Phi = input[0];
                        Theta = input[1];

                        Phi = CoordConvert.sphToTick(Phi);
                        Theta = CoordConvert.vertSphToTick(Theta);

                        mMan.move(Phi, Theta);
                    }

				} else if (givenAct == "status") {
					mMan.status();
				} else if (givenAct == "reload") {
					mMan.reload();
				} else if (givenAct == "reset") {
					mMan.reset();
				} else {
					System.Console.WriteLine("Unknown Command Entered.");
				}
            }
        }
    }
}
