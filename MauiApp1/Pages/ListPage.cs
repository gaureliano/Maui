using System.Collections.ObjectModel;
using MauiApp1.DataAccess;
using MauiApp1.Model;

namespace MauiApp1.Pages;
public partial class ListPage : BasePage
{

    private readonly TestDbContext _dbContext;

    private Entry textField;
    private Button addButton;
    private Button clearButton;
    public ObservableCollection<string> itemsList;
    public ListView ItemList { get; private set; }

    public ListPage(TestDbContext dbContext)
    {
        _dbContext = dbContext;
        itemsList = new ObservableCollection<string>();
    }

    public override void Build()
    {
        // Inicializa a lista de itens
        

        // Criação dos elementos UI
        textField = new Entry
        {
            Placeholder = "Digite algo"
        };

        addButton = new Button
        {
            Text = "Adicionar",
            Command = new Command(AddItem)
        };

        clearButton = new Button
        {
            Text = "Limpar Lista",
            Command = new Command(ClearList)
        };

        ItemList = new ListView
        {
            ItemsSource = _dbContext.ItemLists.Select(x => x.Descricao).ToList()
        };

        // Define o layout da página
        Content = new StackLayout
        {
            Margin = new Thickness(20),
            Children =
            {
                textField,
                new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Orientation= StackOrientation.Horizontal,
                    Children =
                    {
                        addButton,
                        new BoxView { WidthRequest = 10, Color = Color.FromRgb(1000,1000,1000)},
                        clearButton
                    }
                },
                ItemList
            }
        };
    }

    private void AddItem()
    {
        //itemsList.Add(textField.Text);
        _dbContext.ItemLists.Add(new ItemList { Descricao = textField.Text} );
        _dbContext.SaveChanges();

        // Limpa o campo de texto
        textField.Text = string.Empty;
        Build();
        
    }
    private void ClearList()
    {
        var todosItens = _dbContext.ItemLists.ToList();
        _dbContext.RemoveRange(todosItens);
        _dbContext.SaveChanges();

        Build();
    }
}

    

 

