using FreecraftCore;
using FreecraftCore.Serializer;
using Booma.Proxy;

[WireDataContractBaseLinkAttribute(231, typeof(PSOBBGamePacketPayloadServer))]
[WireDataContractAttribute]
public sealed class Stub_0xE7_DTO_PROXY_Server : PSOBBGamePacketPayloadServer, IUnknownPayloadType
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _UnknownBytes;
    public byte[] UnknownBytes
    {
        get
        {
            return _UnknownBytes;
        }

        set
        {
            _UnknownBytes = value;
        }
    }

    public Stub_0xE7_DTO_PROXY_Server()
    {
    }
}