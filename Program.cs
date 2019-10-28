namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Game g = new model.Game();
            view.IView v = new view.SimpleView(); // new view.SwedishView();
            view.InputLetter i = new view.InputLetter();
            controller.PlayGame ctrl = new controller.PlayGame(g, v, i);

            while (ctrl.Play()) ;
        }
    }
}
