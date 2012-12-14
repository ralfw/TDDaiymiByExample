namespace DesktopCalculator.domain
{
    interface IApplication
    {
        int Assemble_number(string digit);
        int Calculate(string op);
    }
}