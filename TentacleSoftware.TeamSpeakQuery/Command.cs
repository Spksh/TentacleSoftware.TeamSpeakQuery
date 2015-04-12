namespace TentacleSoftware.TeamSpeakQuery
{
    /// <summary>
    /// http://media.teamspeak.com/ts3_literature/TeamSpeak%203%20Server%20Query%20Manual.pdf
    /// </summary>
    public enum Command
    {
        help,
        quit,
        login,
        logout,
        version,
        hostinfo,
        instanceinfo,
        instanceedit,
        bindinglist,
        use,
        serverlist,
        serveridgetbyport,
        serverdelete,
        servercreate,
        serverstart,
        serverstop,
        serverprocessstop,
        serverinfo,
        serverrequestconnectioninfo,
        serveredit,
        servergrouplist,
        servergroupadd,
        servergroupdel,
        servergroupcopy,
        servergrouprename,
        servergrouppermlist,
        servergroupaddperm,
        servergroupdelperm,
        servergroupaddclient,
        servergroupdelclient,
        servergroupclientlist,
        servergroupsbyclientid,
        servergroupautoaddperm,
        servergroupautodelperm,
        serversnapshotcreate,
        serversnapshotdeploy,
        servernotifyregister,
        servernotifyunregister,
        sendtextmessage,
        logview,
        logadd,
        gm,
        channellist,
        channelinfo,
        channelfind,
        channelmove,
        channelcreate,
        channeldelete,
        channeledit,
        channelgrouplist,
        channelgroupadd,
        channelgroupdel,
        channelgroupcopy,
        channelgrouprename,
        channelgroupaddperm,
        channelgrouppermlist,
        channelgroupdelperm,
        channelgroupclientlist,
        setclientchannelgroup,
        channelpermlist,
        channeladdperm,
        channeldelperm,
        clientlist,
        clientinfo,
        clientfind,
        clientedit,
        clientdblist,
        clientdbinfo,
        clientdbfind,
        clientdbedit,
        clientdbdelete,
        clientgetids,
        clientgetdbidfromuid,
        clientgetnamefromuid,
        clientgetnamefromdbid,
        clientsetserverquerylogin,
        clientupdate,
        clientmove,
        clientkick,
        clientpoke,
        clientpermlist,
        clientaddperm,
        clientdelperm,
        channelclientpermlist,
        channelclientaddperm,
        channelclientdelperm,
        permissionlist,
        permidgetbyname,
        permoverview,
        permget,
        permfind,
        permreset,
        privilegekeylist,
        privilegekeyadd,
        privilegekeydelete,
        privilegekeyuse,
        messagelist,
        messageadd,
        messagedel,
        messageget,
        messageupdateflag,
        complainlist,
        complainadd,
        complaindelall,
        complaindel,
        banclient,
        banlist,
        banadd,
        bandel,
        bandelall,
        ftinitupload,
        ftinitdownload,
        ftlist,
        ftgetfilelist,
        ftgetfileinfo,
        ftstop,
        ftdeletefile,
        ftcreatedir,
        ftrenamefile,
        customsearch,
        custominfo,
        whoami
    }

    public enum Parameter
    {
        sid,
        port,
        client_login_name,
        client_login_password,
        client_nickname,
        virtualserver_port,
        virtualserver_name,
        type,
        sgid,
        force,
        ssgid,
        tsgid,
        name,
        permid,
        permsid,
        permvalue,
        permnegated,
        permskip,
        cldbid,
        sgtype,
        @event,
        id,
        targetmode,
        target,
        msg,
        lines,
        reverse,
        instance,
        begin_pos,
        loglevel,
        logmsg,
        cid,
        pattern,
        cpid,
        order,
        channel_name,
        cgid,
        scgid,
        tcgid,
        clid,
        start,
        duration,
        cluid,
        cpw,
        reasonid,
        reasonmsg,
        tokentype,
        tokenid1,
        tokenid2,
        tokendescription,
        tokencustomset,
        token,
        message,
        msgid,
        flag,
        tcldbid,
        fcldbid,
        time,
        banreason,
        ip,
        uid,
        banid,
        clientftfid,
        size,
        overwrite,
        resume,
        seekpos,
        path,
        serverftfid,
        delete,
        dirname,
        tcid,
        tcpw,
        oldname,
        newname,
        ident
    }

    public enum Option
    {
        uid,
        @short,
        all,
        onlyoffline,
        permsid,
        names,
        topic,
        flags,
        voice,
        limits,
        icon,
        away,
        times,
        groups,
        info,
        country,
        count,
        @virtual,
        ip
    }
    
    public enum Event
    {
        server,
        channel,
        textserver,
        textchannel,
        textprivate
    }

    public enum UseServerBy
    {
        ServerId,
        Port
    }

    public enum HostMessageMode
    {
        HostMessageMode_LOG = 1, // 1: display message in chatlog
        HostMessageMode_MODAL, // 2: display message in modal dialog
        HostMessageMode_MODALQUIT // 3: display message in modal dialog and close connection
    };

    public enum HostBannerMode
    {
        HostMessageMode_NOADJUST = 0, // 0: do not adjust
        HostMessageMode_IGNOREASPECT, // 1: adjust but ignore aspect ratio (like TeamSpeak 2)
        HostMessageMode_KEEPASPECT // 2: adjust and keep aspect ratio
    };

    public enum Codec
    {
        CODEC_SPEEX_NARROWBAND = 0, // 0: speex narrowband (mono, 16bit, 8kHz)
        CODEC_SPEEX_WIDEBAND, // 1: speex wideband (mono, 16bit, 16kHz)
        CODEC_SPEEX_ULTRAWIDEBAND, // 2: speex ultra-wideband (mono, 16bit, 32kHz)
        CODEC_CELT_MONO // 3: celt mono (mono, 16bit, 48kHz)
    };

    public enum CodecEncryptionMode
    {
        CODEC_CRYPT_INDIVIDUAL = 0, // 0: configure per channel
        CODEC_CRYPT_DISABLED, // 1: globally disabled
        CODEC_CRYPT_ENABLED // 2: globally enabled
    };

    public enum TextMessageTargetMode
    {
        TextMessageTarget_CLIENT = 1, // 1: target is a client
        TextMessageTarget_CHANNEL, // 2: target is a channel
        TextMessageTarget_SERVER // 3: target is a virtual server
    };

    public enum LogLevel
    {
        LogLevel_ERROR = 1, // 1: everything that is really bad
        LogLevel_WARNING, // 2: everything that might be bad
        LogLevel_DEBUG, // 3: output that might help find a problem
        LogLevel_INFO // 4: informational output
    };

    public enum ReasonIdentifier
    {
        REASON_KICK_CHANNEL = 4, // 4: kick client from channel
        REASON_KICK_SERVER // 5: kick client from server
    };
    
    public enum PermissionGroupDatabaseTypes
    {
        PermGroupDBTypeTemplate = 0, // 0: template group (used for new virtual servers)
        PermGroupDBTypeRegular, // 1: regular group (used for regular clients)
        PermGroupDBTypeQuery // 2: global query group (used for ServerQuery clients)
    };
    
    public enum PermissionGroupTypes
    {
        PermGroupTypeServerGroup = 0, // 0: server group permission
        PermGroupTypeGlobalClient, // 1: client specific permission
        PermGroupTypeChannel, // 2: channel specific permission
        PermGroupTypeChannelGroup, // 3: channel group permission
        PermGroupTypeChannelClient // 4: channel-client specific permission
    };
    
    public enum TokenType
    {
        TokenServerGroup = 0, // 0: server group token (id1={groupID} id2=0)
        TokenChannelGroup // 1: channel group token (id1={groupID} id2={channelID})
    };
}
