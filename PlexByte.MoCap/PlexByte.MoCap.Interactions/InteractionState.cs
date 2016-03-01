//////////////////////////////////////////////////////////////
//                      Enum InteractionState                              
//      Author: Christian B. Sax            Date:   2016/02/12
//      Definies possible states an interaction can have
namespace PlexByte.MoCap.Interactions
{
    public enum InteractionState
    {
        Queued,
        Active,
        Finished,
        Expired,
        Cancelled,
    }
}