namespace WhatsNewInNET7APIs;

public sealed class DisposableResource
	: IDisposable
{
	private readonly Stream stream = new MemoryStream();
	private bool disposedValue;

	public long GetStreamSize()
	{
		if(this.disposedValue)
		{
			throw new ObjectDisposedException(this.GetType().FullName);
		}

		return this.stream.Length;
	}

	public long GetStreamSizeThrowIf()
	{
		ObjectDisposedException.ThrowIf(this.disposedValue, this);
		return this.stream.Length;
	}

	private void Dispose(bool disposing)
	{
		if (!this.disposedValue)
		{
			if (disposing)
			{
				this.stream.Dispose();
			}

			this.disposedValue = true;
		}
	}

   public void Dispose() => this.Dispose(true);
}