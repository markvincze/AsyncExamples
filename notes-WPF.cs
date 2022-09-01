// ----------------------
// WPF basic examples
// ----------------------

// Download once, sync
tbServerResponse.Text = "Downloading...";

WebClient wc = new WebClient();

var content = wc.DownloadString(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=3000"));

tbServerResponse.Text = content;

// Download once, async event
tbServerResponse.Text = "Downloading...";

WebClient wc = new WebClient();

wc.DownloadStringCompleted += (sender, e) =>
{
    tbServerResponse.Text = e.Result;
};

wc.DownloadStringAsync(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=3000"));

// Download once, async TPL
tbServerResponse.Text = "Downloading...";

WebClient wc = new WebClient();

var downloadTask = wc.DownloadStringTaskAsync(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=3000"));

downloadTask.ContinueWith(t =>
{
    Dispatcher.Invoke(() =>
    {
        tbServerResponse.Text = t.Result;
    });
});


// Exception with async, not working
try
{
    tbServerResponse.Text = "Downloading...";

    WebClient wc = new WebClient();

    wc.DownloadStringCompleted += (sender, e) =>
    {
        tbServerResponse.Text = e.Result;
    };

    //wc.DownloadStringAsync(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=3000"));
    wc.DownloadStringAsync(new Uri("http://localhost:5000/fail?waitTimeMs=500"));
}
catch(Exception ex)
{
    tbServerResponse.Text = $"Request failed: {ex.Message}";
}

// Download in loop sync
tbServerResponse.Text = "Downloading...";

WebClient wc = new WebClient();

var sb = new StringBuilder();

for (int i = 0; i < 3; i++)
{
    try
    {
        var content = wc.DownloadString(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=500"));
        sb.Append(content);
    }
    catch
    {
        break;
    }
}

tbServerResponse.Text = sb.ToString();

// Download in loop, async event
tbServerResponse.Text = "Downloading...";

WebClient wc = new WebClient();

var sb = new StringBuilder();

var requestCount = 3;

wc.DownloadStringCompleted += (sender, e) =>
{
    if (e.Error != null)
    {
        tbServerResponse.Text = sb.ToString();
        return;
    }

    requestCount--;

    sb.Append(e.Result);

    if (requestCount == 0)
    {
        tbServerResponse.Text = sb.ToString();
    }
    else
    {
        wc.DownloadStringAsync(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=500"));
    }
};

wc.DownloadStringAsync(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=500"));

// Download in a loop, async await TPL
tbServerResponse.Text = "Downloading...";

WebClient wc = new WebClient();

var sb = new StringBuilder();

for (int i = 0; i < 3; i++)
{
    try
    {
        var content = await wc.DownloadStringTaskAsync(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=500"));
        sb.Append(content);
    }
    catch
    {
        break;
    }
}

tbServerResponse.Text = sb.ToString();

// ----------------------
// WPF No Thread Task
// ----------------------
// With event
public StringInputWindow()
{
    InitializeComponent();
}

public string CustomerInput { get; private set; }

private void btnOk_Click(object sender, RoutedEventArgs e)
{
    CustomerInput = tbInput.Text;

    Close();
}

var inputWindow = new StringInputWindow();

inputWindow.Closed += (s, e) =>
{
    lblInput.Content = inputWindow.CustomerInput;
};

inputWindow.Show();

// With TCS + Task
public StringInputWindow()
{
    InitializeComponent();

    tcs = new TaskCompletionSource<string>();
    CustomerInput = tcs.Task;
}

private readonly TaskCompletionSource<string> tcs;

public Task<string> CustomerInput { get; }

private void btnOk_Click(object sender, RoutedEventArgs e)
{
    tcs.SetResult(tbInput.Text);

    Close();
}

var inputWindow = new StringInputWindow();

inputWindow.Show();

lblInput.Content = await inputWindow.CustomerInput;

