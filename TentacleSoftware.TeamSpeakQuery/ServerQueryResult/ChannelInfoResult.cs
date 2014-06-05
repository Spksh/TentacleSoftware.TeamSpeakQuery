namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class ChannelInfoResult : ServerQueryBaseResult
    {
        /// <summary> 
        /// Name of the channel
        /// </summary>
        [PropertyMapping("channel_name", Required = true)]
        public string ChannelName { get; set; }

        /// <summary> 
        /// Topic of the channel
        /// </summary>
        [PropertyMapping("channel_topic")]
        public string ChannelTopic { get; set; }

        /// <summary> 
        /// Description of the channel
        /// </summary>
        [PropertyMapping("channel_description")]
        public string ChannelDescription { get; set; }

        /// <summary> 
        /// Password of the channel
        /// </summary>
        [PropertyMapping("channel_password")]
        public string ChannelPassword { get; set; }

        /// <summary> 
        /// Indicates whether the channel has a password set or not
        /// </summary>
        [PropertyMapping("channel_flag_password")]
        public string ChannelFlagPassword { get; set; }

        /// <summary> 
        /// Codec used by the channel (see Definitions)
        /// </summary>
        [PropertyMapping("channel_codec")]
        public string ChannelCodec { get; set; }

        /// <summary> 
        /// Codec quality used by the channel
        /// </summary>
        [PropertyMapping("channel_codec_quality")]
        public string ChannelCodecQuality { get; set; }

        /// <summary> 
        /// Individual max number of clients for the channel
        /// </summary>
        [PropertyMapping("channel_maxclients")]
        public string ChannelMaxclients { get; set; }

        /// <summary> 
        /// Individual max number of clients for the channel family
        /// </summary>
        [PropertyMapping("channel_maxfamilyclients")]
        public string ChannelMaxfamilyclients { get; set; }

        /// <summary> 
        /// ID of the channel below which the channel is positioned
        /// </summary>
        [PropertyMapping("channel_order", Required = true)]
        public int ChannelOrder { get; set; }

        /// <summary> 
        /// Indicates whether the channel is permanent or not
        /// </summary>
        [PropertyMapping("channel_flag_permanent")]
        public string ChannelFlagPermanent { get; set; }

        /// <summary> 
        /// Indicates whether the channel is semi-permanent or not
        /// </summary>
        [PropertyMapping("channel_flag_semi_permanent")]
        public string ChannelFlagSemiPermanent { get; set; }

        /// <summary> 
        /// Indicates whether the channel is temporary or not
        /// </summary>
        [PropertyMapping("channel_flag_temporary")]
        public string ChannelFlagTemporary { get; set; }

        /// <summary> 
        /// Indicates whether the channel is the virtual servers default channel or not
        /// </summary>
        [PropertyMapping("channel_flag_default")]
        public string ChannelFlagDefault { get; set; }

        /// <summary> 
        /// Indicates whether the channel has a max clients limit or not
        /// </summary>
        [PropertyMapping("channel_flag_maxclients_unlimited")]
        public string ChannelFlagMaxclientsUnlimited { get; set; }

        /// <summary> 
        /// Indicates whether the channel has a max family clients limit or not
        /// </summary>
        [PropertyMapping("channel_flag_maxfamilyclients_unlimited")]
        public string ChannelFlagMaxfamilyclientsUnlimited { get; set; }

        /// <summary> 
        /// Indicates whether the channel inherits the max family clients from his parent channel or not
        /// </summary>
        [PropertyMapping("channel_flag_maxfamilyclients_inherited")]
        public string ChannelFlagMaxfamilyclientsInherited { get; set; }

        /// <summary> 
        /// Needed talk power for this channel
        /// </summary>
        [PropertyMapping("channel_needed_talk_power")]
        public string ChannelNeededTalkPower { get; set; }

        /// <summary> 
        /// Needed subscribe power for this channel
        /// </summary>
        [PropertyMapping("channel_needed_subscribe_power")]
        public string ChannelNeededSubscribePower { get; set; }

        /// <summary> 
        /// Phonetic name of the channel
        /// </summary>
        [PropertyMapping("channel_name_phonetic")]
        public string ChannelNamePhonetic { get; set; }

        /// <summary> 
        /// Path of the channels file repository
        /// </summary>
        [PropertyMapping("channel_filepath")]
        public string ChannelFilepath { get; set; }

        /// <summary> 
        /// Indicates whether the channel is silenced or not
        /// </summary>
        [PropertyMapping("channel_forced_silence")]
        public string ChannelForcedSilence { get; set; }

        /// <summary> 
        /// CRC32 checksum of the channel icon
        /// </summary>
        [PropertyMapping("channel_icon_id")]
        public string ChannelIconId { get; set; }

        /// <summary> 
        /// Indicates whether speech data transmitted in this channel is encrypted or not
        /// </summary>
        [PropertyMapping("channel_codec_is_unencrypted")]
        public string ChannelCodecIsUnencrypted { get; set; }

        /// <summary> 
        /// The channels parent ID.
        /// </summary>
        [PropertyMapping("pid", Required = true)]
        public int Pid { get; set; }

        /// <summary> 
        /// The channels ID
        /// </summary>
        [PropertyMapping("cid")]
        public int Cid { get; set; }

        [PropertyMapping("total_clients_family")]
        public string TotalClientsFamily { get; set; }

        [PropertyMapping("total_clients")]
        public string TotalClients { get; set; }

        [PropertyMapping("channel_security_salt")]
        public string ChannelSecuritySalt { get; set; }

        [PropertyMapping("channel_delete_delay")]
        public string ChannelDeleteDelay { get; set; }

        [PropertyMapping("channel_codec_latency_factor")]
        public string ChannelCodecLatencyFactor { get; set; }

        [PropertyMapping("channel_flag_private")]
        public string ChannelFlagPrivate { get; set; }

        [PropertyMapping("seconds_empty")]
        public string SecondsEmpty { get; set; }

        public override bool Parse(string message)
        {
            // Is this an error response?
            if (base.Parse(message))
            {
                return true;
            }

            if (this.MapPropertyValuesFrom(message))
            {
                Success = true;
                Response = message;

                return true;
            }

            return false;
        }
    }
}
