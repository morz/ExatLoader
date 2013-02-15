/* -----------------------------------------------------------------
 * 
 * LED initialization code written by Levent S. 
 * E-mail: ls@izdir.com
 * 
 * This code is provided without implied warranty so the author is
 * not responsible about damages by the use of the code.
 * 
 * You can use this code for any purpose even in any commercial 
 * distributions by referencing my name. 
 * 
 * ! Don't remove or alter this notice in any distribution !
 * 
 * -----------------------------------------------------------------*/
using System;
using System.Runtime.InteropServices;

public class Lpt
{
    [DllImport("inpout32.dll")]
    public static extern UInt32 IsInpOutDriverOpen();
    [DllImport("inpout32.dll")]
    public static extern void Out32(short PortAddress, short Data);
    [DllImport("inpout32.dll")]
    public static extern char Inp32(short PortAddress);

    [DllImport("inpout32.dll")]
    public static extern void DlPortWritePortUshort(short PortAddress, ushort Data);
    [DllImport("inpout32.dll")]
    public static extern ushort DlPortReadPortUshort(short PortAddress);

    [DllImport("inpout32.dll")]
    public static extern void DlPortWritePortUlong(int PortAddress, uint Data);
    [DllImport("inpout32.dll")]
    public static extern uint DlPortReadPortUlong(int PortAddress);

    [DllImport("inpoutx64.dll")]
    public static extern bool GetPhysLong(ref int PortAddress, ref uint Data);
    [DllImport("inpoutx64.dll")]
    public static extern bool SetPhysLong(ref int PortAddress, ref uint Data);


    [DllImport("inpoutx64.dll", EntryPoint = "IsInpOutDriverOpen")]
    public static extern UInt32 IsInpOutDriverOpen_x64();
    [DllImport("inpoutx64.dll", EntryPoint = "Out32")]
    public static extern void Out32_x64(short PortAddress, short Data);
    [DllImport("inpoutx64.dll", EntryPoint = "Inp32")]
    public static extern char Inp32_x64(short PortAddress);

    [DllImport("inpoutx64.dll", EntryPoint = "DlPortWritePortUshort")]
    public static extern void DlPortWritePortUshort_x64(short PortAddress, ushort Data);
    [DllImport("inpoutx64.dll", EntryPoint = "DlPortReadPortUshort")]
    public static extern ushort DlPortReadPortUshort_x64(short PortAddress);

    [DllImport("inpoutx64.dll", EntryPoint = "DlPortWritePortUlong")]
    public static extern void DlPortWritePortUlong_x64(int PortAddress, uint Data);
    [DllImport("inpoutx64.dll", EntryPoint = "DlPortReadPortUlong")]
    public static extern uint DlPortReadPortUlong_x64(int PortAddress);

    [DllImport("inpoutx64.dll", EntryPoint = "GetPhysLong")]
    public static extern bool GetPhysLong_x64(ref int PortAddress, ref uint Data);
    [DllImport("inpoutx64.dll", EntryPoint = "SetPhysLong")]
    public static extern bool SetPhysLong_x64(ref int PortAddress, ref uint Data);
}