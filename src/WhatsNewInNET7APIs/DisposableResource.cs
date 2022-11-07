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

	public long GetStreamSizeNew()
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

			// TODO: free unmanaged resources (unmanaged objects) and override finalizer
			// TODO: set large fields to null
			this.disposedValue = true;
		}
	}

	// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
	// ~DisposableResource()
	// {
	//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
	//     Dispose(disposing: false);
	// }

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		this.Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}