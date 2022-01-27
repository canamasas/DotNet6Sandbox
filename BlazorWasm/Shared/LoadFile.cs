using W8lessLabs.Blazor.LocalFiles;

namespace BlazorWasm.Shared
{
    public class LoadFile
    {
        public SelectedFile SelectedFile { get; set; }
        public bool IsLoaded { get; set; }
        public int LoadedSize { get; set; }
    }

}
