using System;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using TechTalk.SpecFlow;

namespace SystemTest
{
    [Binding]
    public class MicroPowerOnceSteps
    {
        private IOutput output;
        private Timer timer;
        private Display display;
        private PowerTube powerTube;
        private CookController cooker;
        private UserInterface ui;
        private Light light;
        private Button powerButton;
        private Button timeButton;
        private Button startCancelButton;
        private Door door;

        [Given(@"the oven is reset")]
        public void GivenTheOvenIsReset()
        {
            output = Substitute.For<IOutput>();
            powerButton = new Button();
            timeButton = new Button();
            startCancelButton = new Button();
            door = new Door();
            timer = new Timer();
            display = new Display(output);
            powerTube = new PowerTube(output);
            light = new Light(output);
            cooker = new CookController(timer, display, powerTube);
            ui = new UserInterface(
                powerButton, timeButton, startCancelButton,
                door,
                display, light, cooker);
            cooker.UI = ui;
        }
        
        [When(@"I press the power button (.*) time\(s\)")]
        public void WhenIPressThePowerButtonTimeS(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                powerButton.Press();
            }
        }
        
        [Then(@"the display show (.*) W")]
        public void ThenTheDisplayShowW(int p0)
        {
            output.
                Received().
                OutputLine(Arg.Is<string>(str =>
                    str.Contains($"Display shows: {p0} W")));

        }
    }
}
