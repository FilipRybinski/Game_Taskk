using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsInput;
using WindowsInput.Native;

namespace minecraft_poker
{
    class Program
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        static void Main(string[] args)
        {
            Console.SetWindowSize(10, );
            Process[] ps = Process.GetProcessesByName("VirtualMT2");
            Console.WriteLine(ps.Length);
            Process p = ps.FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                InputSimulator isim = new InputSimulator();
                Thread.Sleep(1000);
                IntPtr Game = GetForegroundWindow();
                while (true)
                {
                    Thread.Sleep(1000);
                    isim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.SPACE);
                    isim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_Z);
                    Thread.Sleep(1000);
                    isim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_Z);
                    isim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.F3);
                    isim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.F3);
                    Thread.Sleep(1000);
                    isim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.F3);
                    isim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.SPACE);
                    IntPtr Current = GetForegroundWindow();
                    Console.WriteLine("WORKS");
                    if(Game != Current){

                        while (Game != Current) {
                            Console.WriteLine("PAUZE");
                            IntPtr tmp = GetForegroundWindow();
                            if (Game == tmp) { Console.WriteLine("UNPAUZE");
                                break;
                            }
                            Thread.Sleep(1000);
                        };
                    }

                    
                }
                } 
            Console.ReadKey();
        } 
          
    }
}
