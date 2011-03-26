namespace Repository
{
    public static class RepositoryExtensions
    {
        public static Microsoft.SqlServer.Types.SqlGeometry AsSqlGeometry(this byte[] binary)
        {
            var ret = new Microsoft.SqlServer.Types.SqlGeometry();

            using (var stream = new System.IO.MemoryStream(binary))
            using (var rdr = new System.IO.BinaryReader(stream))
            {
                ret.Read(rdr);
            }
            return ret;
        }
    }
}