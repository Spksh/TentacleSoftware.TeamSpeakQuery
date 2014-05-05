namespace TentacleSoftware.TeamSpeakQuery.NotifyResult
{
    [TypeMapping("notifycliententerview")]
    public class NotifyClientEnterViewResult : NotifyBaseResult
    {
        [PropertyMapping("cfid", Required = true)]
        public string Cfid { get; set; }

        [PropertyMapping("ctid", Required = true)]
        public string Ctid { get; set; }

        [PropertyMapping("reasonid", Required = true)]
        public string Reasonid { get; set; }

        [PropertyMapping("clid", Required = true)]
        public string Clid { get; set; }

        [PropertyMapping("client_unique_identifier", Required = true)]
        public string ClientUniqueIdentifier { get; set; }

        [PropertyMapping("client_nickname", Required = true)]
        public string ClientNickname { get; set; }

        [PropertyMapping("client_input_muted", Required = true)]
        public string ClientInputMuted { get; set; }

        [PropertyMapping("client_output_muted", Required = true)]
        public string ClientOutputMuted { get; set; }

        [PropertyMapping("client_outputonly_muted", Required = true)]
        public string ClientOutputonlyMuted { get; set; }

        [PropertyMapping("client_input_hardware", Required = true)]
        public string ClientInputHardware { get; set; }

        [PropertyMapping("client_output_hardware", Required = true)]
        public string ClientOutputHardware { get; set; }

        [PropertyMapping("client_meta_data", Required = true)]
        public string ClientMetaData { get; set; }

        [PropertyMapping("client_is_recording", Required = true)]
        public string ClientIsRecording { get; set; }

        [PropertyMapping("client_database_id", Required = true)]
        public string ClientDatabaseId { get; set; }

        [PropertyMapping("client_channel_group_id", Required = true)]
        public string ClientChannelGroupId { get; set; }

        [PropertyMapping("client_servergroups", Required = true)]
        public string ClientServergroups { get; set; }

        [PropertyMapping("client_away", Required = true)]
        public string ClientAway { get; set; }

        [PropertyMapping("client_away_message", Required = true)]
        public string ClientAwayMessage { get; set; }

        [PropertyMapping("client_type", Required = true)]
        public string ClientType { get; set; }

        [PropertyMapping("client_flag_avatar", Required = true)]
        public string ClientFlagAvatar { get; set; }

        [PropertyMapping("client_talk_power", Required = true)]
        public string ClientTalkPower { get; set; }

        [PropertyMapping("client_talk_request", Required = true)]
        public string ClientTalkRequest { get; set; }

        [PropertyMapping("client_talk_request_msg", Required = true)]
        public string ClientTalkRequestMsg { get; set; }

        [PropertyMapping("client_description", Required = true)]
        public string ClientDescription { get; set; }

        [PropertyMapping("client_is_talker", Required = true)]
        public string ClientIsTalker { get; set; }

        [PropertyMapping("client_is_priority_speaker", Required = true)]
        public string ClientIsPrioritySpeaker { get; set; }

        [PropertyMapping("client_unread_messages", Required = true)]
        public string ClientUnreadMessages { get; set; }

        [PropertyMapping("client_nickname_phonetic", Required = true)]
        public string ClientNicknamePhonetic { get; set; }

        [PropertyMapping("client_needed_serverquery_view_power", Required = true)]
        public string ClientNeededServerqueryViewPower { get; set; }

        [PropertyMapping("client_icon_id", Required = true)]
        public string ClientIconId { get; set; }

        [PropertyMapping("client_is_channel_commander", Required = true)]
        public string ClientIsChannelCommander { get; set; }

        [PropertyMapping("client_country", Required = true)]
        public string ClientCountry { get; set; }

        [PropertyMapping("client_channel_group_inherited_channel_id", Required = true)]
        public string ClientChannelGroupInheritedChannelId { get; set; }

        [PropertyMapping("client_badges", Required = true)]
        public string ClientBadges { get; set; }

        public override bool Parse(string notification)
        {
            if (this.MapPropertyValuesFrom(notification))
            {
                return true;
            }

            return false;
        }
    }
}
