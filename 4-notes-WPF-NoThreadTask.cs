// With event
public StringInputWindow()
{
    InitializeComponent();
}

public string UserInput { get; private set; }

private void btnOk_Click(object sender, RoutedEventArgs e)
{
    UserInput = tbInput.Text;

    Close();
}

var inputWindow = new StringInputWindow();

inputWindow.Closed += (s, e) =>
{
    lblInput.Content = inputWindow.UserInput;
};

inputWindow.Show();

// With TCS + Task
public StringInputWindow()
{
    InitializeComponent();

    tcs = new TaskCompletionSource<string>();
    UserInput = tcs.Task;
}

private readonly TaskCompletionSource<string> tcs;

public Task<string> UserInput { get; }

private void btnOk_Click(object sender, RoutedEventArgs e)
{
    tcs.SetResult(tbInput.Text);

    Close();
}

var inputWindow = new StringInputWindow();

inputWindow.Show();

lblInput.Content = await inputWindow.UserInput;

