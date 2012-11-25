﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication2
{
    // TAPI hat sabitlerini kapsayan sınıfımız.
    public class Enums
    {
        // Hattı başlatma (lineInitializeEx) zamanında, seçilecek
        // olay bildirimi mekanizması enum sabitleri.
        public enum LineInitializeExOptions : uint
        {
            LINEINITIALIZEEXOPTION_USEHIDDENWINDOW = 0x00000001,
            LINEINITIALIZEEXOPTION_USEEVENT = 0x00000002,
            LINEINITIALIZEEXOPTION_USECOMPLETIONPORT = 0x00000003
        }

        // Hattın kullandığı string türü - ASCII, Unicode...
        public enum StringFormat : uint
        {
            STRINGFORMAT_ASCII = 0x00000001,
            STRINGFORMAT_DBCS = 0x00000002,
            STRINGFORMAT_UNICODE = 0x00000003,
            STRINGFORMAT_BINARY = 0x00000004
        }

        // Çağrıyla ilgili olarak, uygulamanın sahip olduğu ayrıcalıkların enum sabitleri.
        [Flags]
        public enum LineCallPrivilege : uint
        {
            // Uygulamaya ait özel bir hak yok.
            LINECALLPRIVILEGE_NONE = 0x00000001,
            // Uygulama çağrıyı sorgular ve durmunu takip eder.
            LINECALLPRIVILEGE_MONITOR = 0x00000002,
            // Uygulama çağrıyı kendi amacı doğrultusunda yönetebilir.
            LINECALLPRIVILEGE_OWNER = 0x00000004
        }

        // Hat durum olaylarıyla ilgili enum sabitleri.
        [Flags]
        public enum LineDevState : uint
        {
            LINEDEVSTATE_OTHER = 0x00000001,
            LINEDEVSTATE_RINGING = 0x00000002,
            LINEDEVSTATE_CONNECTED = 0x00000004,
            LINEDEVSTATE_DISCONNECTED = 0x00000008,
            LINEDEVSTATE_MSGWAITON = 0x00000010,
            LINEDEVSTATE_MSGWAITOFF = 0x00000020,
            LINEDEVSTATE_INSERVICE = 0x00000040,
            LINEDEVSTATE_OUTOFSERVICE = 0x00000080,
            LINEDEVSTATE_MAINTENANCE = 0x00000100,
            LINEDEVSTATE_OPEN = 0x00000200,
            LINEDEVSTATE_CLOSE = 0x00000400,
            LINEDEVSTATE_NUMCALLS = 0x00000800,
            LINEDEVSTATE_NUMCOMPLETIONS = 0x00001000,
            LINEDEVSTATE_TERMINALS = 0x00002000,
            LINEDEVSTATE_ROAMMODE = 0x00004000,
            LINEDEVSTATE_BATTERY = 0x00008000,
            LINEDEVSTATE_SIGNAL = 0x00010000,
            LINEDEVSTATE_DEVSPECIFIC = 0x00020000,
            LINEDEVSTATE_REINIT = 0x00040000,
            LINEDEVSTATE_LOCK = 0x00080000,
            LINEDEVSTATE_CAPSCHANGE = 0x00100000,
            LINEDEVSTATE_CONFIGCHANGE = 0x00200000,
            LINEDEVSTATE_TRANSLATECHANGE = 0x00400000,
            LINEDEVSTATE_COMPLCANCEL = 0x00800000,
            LINEDEVSTATE_REMOVED = 0x01000000
        }

        // Adres durumu ögeleri enum sabitleri.
        [Flags]
        public enum LineAddressState : uint
        {
            LINEADDRESSSTATE_OTHER = 0x00000001,
            LINEADDRESSSTATE_DEVSPECIFIC = 0x00000002,
            LINEADDRESSSTATE_INUSEZERO = 0x00000004,
            LINEADDRESSSTATE_INUSEONE = 0x00000008,
            LINEADDRESSSTATE_INUSEMANY = 0x00000010,
            LINEADDRESSSTATE_NUMCALLS = 0x00000020,
            LINEADDRESSSTATE_FORWARD = 0x00000040,
            LINEADDRESSSTATE_TERMINALS = 0x00000080,
            LINEADDRESSSTATE_CAPSCHANGE = 0x00000100
        }

        // Taşıyıcı biçimleri enum sabitleri
        [Flags]
        public enum LineBearerMode : uint
        {
            LINEBEARERMODE_VOICE = 0x00000001,
            LINEBEARERMODE_SPEECH = 0x00000002,
            LINEBEARERMODE_MULTIUSE = 0x00000004,
            LINEBEARERMODE_DATA = 0x00000008,
            LINEBEARERMODE_ALTSPEECHDATA = 0x00000010,
            LINEBEARERMODE_NONCALLSIGNALING = 0x00000020,
            LINEBEARERMODE_PASSTHROUGH = 0x00000040,
            LINEBEARERMODE_RESTRICTEDDATA = 0x00000080
        }

        // Kullanılabilir-uygun hat özellikleri enum sabitleri.
        [Flags]
        public enum LineFeature : uint
        {
            LINEFEATURE_DEVSPECIFIC = 0x00000001,
            LINEFEATURE_DEVSPECIFICFEAT = 0x00000002,
            LINEFEATURE_FORWARD = 0x00000004,
            LINEFEATURE_MAKECALL = 0x00000008,
            LINEFEATURE_SETMEDIACONTROL = 0x00000010,
            LINEFEATURE_SETTERMINAL = 0x00000020,
            LINEFEATURE_SETDEVSTATUS = 0x00000040,
            LINEFEATURE_FORWARDFWD = 0x00000080,
            LINEFEATURE_FORWARDDND = 0x00000100
        }

        // Çağrı ortamı enum sabitleri - Ses modemi, fax, data modem, video v.b.
        [Flags]
        public enum LineMediaMode : uint
        {
            LINEMEDIAMODE_UNKNOWN = 0x00000002,
            LINEMEDIAMODE_INTERACTIVEVOICE = 0x00000004,
            LINEMEDIAMODE_AUTOMATEDVOICE = 0x00000008,
            LINEMEDIAMODE_DATAMODEM = 0x00000010,
            LINEMEDIAMODE_G3FAX = 0x00000020,
            LINEMEDIAMODE_TDD = 0x00000040,
            LINEMEDIAMODE_G4FAX = 0x00000080,
            LINEMEDIAMODE_DIGITALDATA = 0x00000100,
            LINEMEDIAMODE_TELETEX = 0x00000200,
            LINEMEDIAMODE_VIDEOTEX = 0x00000400,
            LINEMEDIAMODE_TELEX = 0x00000800,
            LINEMEDIAMODE_MIXED = 0x00001000,
            LINEMEDIAMODE_ADSI = 0x00002000,
            LINEMEDIAMODE_VOICEVIEW = 0x00004000,
            LINEMEDIAMODE_VIDEO = 0x00008000
        }

        // Arama-çağrı durumları enum sabitleri.
        [Flags]
        public enum LineCallState : uint
        {
            LINECALLSTATE_IDLE = 0x00000001,
            LINECALLSTATE_OFFERING = 0x00000002,
            LINECALLSTATE_ACCEPTED = 0x00000004,
            LINECALLSTATE_DIALTONE = 0x00000008,
            LINECALLSTATE_DIALING = 0x00000010,
            LINECALLSTATE_RINGBACK = 0x00000020,
            LINECALLSTATE_BUSY = 0x00000040,
            LINECALLSTATE_SPECIALINFO = 0x00000080,
            LINECALLSTATE_CONNECTED = 0x00000100,
            LINECALLSTATE_PROCEEDING = 0x00000200,
            LINECALLSTATE_ONHOLD = 0x00000400,
            LINECALLSTATE_CONFERENCED = 0x00000800,
            LINECALLSTATE_ONHOLDPENDCONF = 0x00001000,
            LINECALLSTATE_ONHOLDPENDTRANSFER = 0x00002000,
            LINECALLSTATE_DISCONNECTED = 0x00004000,
            LINECALLSTATE_UNKNOWN = 0x00008000
        }

        // Telefon - hat mesajları. Bkz. Tapi.h
        public enum LineDeviceMessages : int
        {
            LINE_ADDRESSSTATE = 0,
            LINE_CALLINFO,
            LINE_CALLSTATE,
            LINE_CLOSE,
            LINE_DEVSPECIFIC,
            LINE_DEVSPECIFICFEATURE,
            LINE_GATHERDIGITS,
            LINE_GENERATE,
            LINE_LINEDEVSTATE,
            LINE_MONITORDIGITS,
            LINE_MONITORMEDIA,
            LINE_MONITORTONE,
            LINE_REPLY,
            LINE_REQUEST,
            PHONE_BUTTON,
            PHONE_CLOSE,
            PHONE_DEVSPECIFIC,
            PHONE_REPLY,
            PHONE_STATE,
            LINE_CREATE,
            PHONE_CREATE,
            LINE_AGENTSPECIFIC,
            LINE_AGENTSTATUS,
            LINE_APPNEWCALL,
            LINE_PROXYREQUEST,
            LINE_REMOVE,
            PHONE_REMOVE
        }
    }//Enums
}