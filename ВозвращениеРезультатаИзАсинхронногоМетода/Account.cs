using System;

namespace ВозвращениеРезультатаИзАсинхронногоМетода;

public class Account
{
    int sum = 0;
    public event EventHandler<string>? Added;
    public void Put(int sum)
    {
        this.sum += sum;
        Added?.Invoke(this, $"На счет поступило {sum} $");
    }
}
