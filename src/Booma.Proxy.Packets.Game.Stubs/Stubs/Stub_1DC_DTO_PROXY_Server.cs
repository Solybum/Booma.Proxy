using FreecraftCore;
using FreecraftCore.Serializer;
using Booma.Proxy;

[WireDataContractBaseLinkAttribute(476, typeof(PSOBBGamePacketPayloadServer))]
[WireDataContractAttribute]
public sealed class Stub_0x01DC_DTO_PROXY_Server : PSOBBGamePacketPayloadServer, IUnknownPayloadType
{
    public override bool isFlagsSerialized
    {
        get;
    }

    = false;
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

    public Stub_0x01DC_DTO_PROXY_Server()
    {
    }
}