namespace CrossPlatformDesktopProject.CommandController
{
    public interface ICommand
    {
        public void Execute(int id);
        public void Unexecute();
    }
}