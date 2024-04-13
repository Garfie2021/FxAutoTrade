object APITestForm: TAPITestForm
  Left = 263
  Top = 171
  Caption = 'FX API Test Application'
  ClientHeight = 566
  ClientWidth = 775
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Splitter1: TSplitter
    Left = 377
    Top = 57
    Width = 8
    Height = 509
    ExplicitHeight = 511
  end
  object TopPanel: TPanel
    Left = 0
    Top = 0
    Width = 775
    Height = 57
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 2
    object SchemaLabel: TLabel
      Left = 9
      Top = 8
      Width = 39
      Height = 13
      Caption = 'Schema'
    end
    object LoginLabel: TLabel
      Left = 162
      Top = 7
      Width = 26
      Height = 13
      Caption = 'Login'
    end
    object PasswordLabel: TLabel
      Left = 296
      Top = 7
      Width = 46
      Height = 13
      Caption = 'Password'
    end
    object IDLabel: TLabel
      Left = 439
      Top = 7
      Width = 31
      Height = 13
      Caption = 'API ID'
    end
    object ConnectButton: TButton
      Left = 5
      Top = 29
      Width = 75
      Height = 25
      Caption = 'Connect'
      TabOrder = 0
      OnClick = ConnectButtonClick
    end
    object DisconnectButton: TButton
      Left = 85
      Top = 29
      Width = 75
      Height = 25
      Caption = 'Disconnect'
      TabOrder = 1
      OnClick = DisconnectButtonClick
    end
    object StatusGroup: TGroupBox
      Left = 560
      Top = 0
      Width = 215
      Height = 57
      Align = alRight
      Caption = 'Status'
      TabOrder = 2
      object StatusPanel: TPanel
        Left = 2
        Top = 15
        Width = 211
        Height = 40
        Align = alClient
        BevelOuter = bvNone
        Caption = 'OFFLINE'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 0
      end
    end
    object SchemaEdit: TEdit
      Left = 59
      Top = 5
      Width = 86
      Height = 21
      TabOrder = 3
    end
    object LoginEdit: TEdit
      Left = 194
      Top = 4
      Width = 79
      Height = 21
      TabOrder = 4
    end
    object PasswordEdit: TEdit
      Left = 360
      Top = 4
      Width = 73
      Height = 21
      TabOrder = 5
    end
    object IDEdit: TEdit
      Left = 478
      Top = 4
      Width = 75
      Height = 21
      TabOrder = 6
    end
  end
  object DataGroupBox: TGroupBox
    Left = 0
    Top = 57
    Width = 377
    Height = 509
    Align = alLeft
    Caption = 'Data Log'
    TabOrder = 0
    object DataBox: TMemo
      Left = 2
      Top = 15
      Width = 373
      Height = 492
      Align = alClient
      Font.Charset = RUSSIAN_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Courier New'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
  end
  object MessageGroupBox: TGroupBox
    Left = 385
    Top = 57
    Width = 390
    Height = 509
    Align = alClient
    Caption = 'Message Log (last 100 messages)'
    TabOrder = 1
    object MsgBox: TMemo
      Left = 2
      Top = 15
      Width = 386
      Height = 492
      Align = alClient
      Font.Charset = RUSSIAN_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Courier New'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
  end
end
