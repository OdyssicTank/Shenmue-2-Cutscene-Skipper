using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Shenmue_2_Skipper
{

    public partial class ShenmueForm : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, out int lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        const string processName = "Shenmue2";

        private volatile bool buttonEnabled = false;
        public ShenmueForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var gameCheckerThread = new Thread(new ThreadStart(GameCheckerThread));
            gameCheckerThread.Start();
        }

        //Checks if the game is open, makes the button disabled if the game isn't open
        void GameCheckerThread()
        {
            while (true)
            {
                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length == 0)
                {
                    lblGameProcess.Invoke(new Action(() =>
                    {
                        lblGameProcess.ForeColor = Color.Red;
                        lblGameProcess.Text = "Shenmue 2 not found";
                        btnToggleSkipper.Enabled = false;
                        btnToggleSkipper.Text = "Enable Cutscene skipper";
                        btnLaunch.Enabled = true;
                    }));
                } 
                else
                {
                    lblGameProcess.Invoke(new Action(() =>
                    {
                        lblGameProcess.ForeColor = Color.Green;
                        lblGameProcess.Text = "Shenmue 2 found";
                        btnToggleSkipper.Enabled = true;
                        btnLaunch.Enabled = false;
                    }));
                }

                Thread.Sleep(1000);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        //After the game is open, the button becomes enabled. If the button is pressed, it changes the button to disable button.
        //If the game is closed, the button is disabled and game is no longer found.
        private void btnToggleSkipper_Click(object sender, EventArgs e)
        {
            if (buttonEnabled)
            {
                buttonEnabled = false;
                btnToggleSkipper.Invoke(new Action(() =>
                {
                    btnToggleSkipper.Text = "Enable Cutscene skipper";
                }));
            }
            else
            {
                buttonEnabled = true;
                btnToggleSkipper.Invoke(new Action(() =>
                {
                    btnToggleSkipper.Text = "Disable Cutscene skipper";
                }));
                Task.Run(() =>
                {
                    int value = 0;

                    Process[] processes = Process.GetProcessesByName(processName);

                    if (processes.Length == 0)
                        return;

                    Process gameProcess = processes[0];
                    IntPtr processHandle = OpenProcess(ProcessAccessFlags.All, false, gameProcess.Id);

                    IntPtr cutsceneEnabledAddress = (IntPtr)gameProcess.MainModule?.BaseAddress + 0x3BF8A90; // 0 when cutscene is unskippable, 1 when cutscene is skipable

                    while (buttonEnabled && processes.Length >= 1)
                    {
                        ReadProcessMemory(processHandle, cutsceneEnabledAddress, out value, sizeof(int), out _);

                        if (value == 0)
                        {
                            WriteProcessMemory(processHandle, cutsceneEnabledAddress, new byte[] { 0x01 }, 1, out _);
                        }

                        processes = Process.GetProcessesByName(processName);
                        Thread.Sleep(1);
                    }
                });
            }
            
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            string pathToExe = @"C:\Users\odyss\Documents\Shenmue\sm2\Shenmue2.exe";

            Process.Start(pathToExe);
        }
    }
}