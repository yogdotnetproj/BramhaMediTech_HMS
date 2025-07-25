﻿ /*
 * FCKeditor - The text editor for internet
 * Copyright (C) 2003-2005 Frederico Caldeira Knabben
 * 
 * Licensed under the terms of the GNU Lesser General Public License:
 * 		http://www.opensource.org/licenses/lgpl-license.php
 * 
 * For further information visit:
 * 		http://www.fckeditor.net/
 * 
 * File Name: eu.js
 * 	Basque language file.
 * 	Euskara hizkuntza fitxategia.
 * 
 * File Authors:
 * 		Ibon Igartua (Librezale.org)
 */

var FCKLang =
{
// Language direction : "ltr" (left to right) or "rtl" (right to left).
Dir					: "ltr",

ToolbarCollapse		: "Estutu Tresna Barra",
ToolbarExpand		: "Hedatu Tresna Barra",

// Toolbar Items and Context Menu
Save				: "Gorde",
NewPage				: "Orrialde Berria",
Preview				: "Aurrebista",
Cut					: "Ebaki",
Copy				: "Kopiatu",
Paste				: "Itsatsi",
PasteText			: "Itsatsi testu bezala",
PasteWord			: "Itsatsi Word-etik",
Print				: "Inprimatu",
SelectAll			: "Hautatu dena",
RemoveFormat		: "Kendu Formatoa",
InsertLinkLbl		: "Esteka",
InsertLink			: "Txertatu/Editatu Esteka",
RemoveLink			: "Kendu Esteka",
Anchor				: "Aingura",
InsertImageLbl		: "Irudia",
InsertImage			: "Txertatu/Editatu Irudia",
InsertFlashLbl		: "Flasha",
InsertFlash			: "Txertatu/Editatu Flasha",
InsertTableLbl		: "Taula",
InsertTable			: "Txertatu/Editatu Taula",
InsertLineLbl		: "Lerroa",
InsertLine			: "Txertatu Marra Horizontala",
InsertSpecialCharLbl: "Karaktere Berezia",
InsertSpecialChar	: "Txertatu Karaktere Berezia",
InsertSmileyLbl		: "Aurpegierak",
InsertSmiley		: "Txertatu Aurpegierak",
About				: "FCKeditor-ri buruz",
Bold				: "Lodia",
Italic				: "Etzana",
Underline			: "Azpimarratu",
StrikeThrough		: "Marratua",
Subscript			: "Azpi-indize",
Superscript			: "Goi-indize",
LeftJustify			: "Lerrokatu Ezkerrean",
CenterJustify		: "Lerrokatu Erdian",
RightJustify		: "Lerrokatu Eskuman",
BlockJustify		: "Justifikatu",
DecreaseIndent		: "Txikitu Koska",
IncreaseIndent		: "Handitu Koska",
Undo				: "Desegin",
Redo				: "Berregin",
NumberedListLbl		: "Zenbakidun Zerrenda",
NumberedList		: "Txertatu/Kendu Zenbakidun zerrenda",
BulletedListLbl		: "Buletdun Zerrenda",
BulletedList		: "Txertatu/Kendu Buletdun zerrenda",
ShowTableBorders	: "Erakutsi Taularen Ertzak",
ShowDetails			: "Erakutsi Xehetasunak",
Style				: "Estiloa",
FontFormat			: "Formatoa",
Font				: "Letra-tipoa",
FontSize			: "Tamaina",
TextColor			: "Testu Kolorea",
BGColor				: "Atzeko kolorea",
Source				: "HTML Iturburua",
Find				: "Bilatu",
Replace				: "Ordezkatu",
SpellCheck			: "Ortografia",
UniversalKeyboard	: "Teklatu Unibertsala",

Form			: "Formularioa",
Checkbox		: "Kontrol-laukia",
RadioButton		: "Aukera-botoia",
TextField		: "Testu Eremua",
Textarea		: "Testu-area",
HiddenField		: "Ezkutuko Eremua",
Button			: "Botoia",
SelectionField	: "Hautespen Eremua",
ImageButton		: "Irudi Botoia",

// Context Menu
EditLink			: "Aldatu Esteka",
InsertRow			: "Txertatu Errenkada",
DeleteRows			: "Ezabatu Errenkadak",
InsertColumn		: "Txertatu Zutabea",
DeleteColumns		: "Ezabatu Zutabeak",
InsertCell			: "Txertatu Gelaxka",
DeleteCells			: "Kendu Gelaxkak",
MergeCells			: "Batu Gelaxkak",
SplitCell			: "Zatitu Gelaxka",
CellProperties		: "Gelaxkaren Ezaugarriak",
TableProperties		: "Taularen Ezaugarriak",
ImageProperties		: "Irudiaren Ezaugarriak",
FlashProperties		: "Flasharen Ezaugarriak",

AnchorProp			: "Ainguraren Ezaugarriak",
ButtonProp			: "Botoiaren Ezaugarriak",
CheckboxProp		: "Kontrol-laukiko Ezaugarriak",
HiddenFieldProp		: "Ezkutuko Eremuaren Ezaugarriak",
RadioButtonProp		: "Aukera-botoiaren Ezaugarriak",
ImageButtonProp		: "Irudi Botoiaren Ezaugarriak",
TextFieldProp		: "Testu Eremuaren Ezaugarriak",
SelectionFieldProp	: "Hautespen Eremuaren Ezaugarriak",
TextareaProp		: "Testu-arearen Ezaugarriak",
FormProp			: "Formularioaren Ezaugarriak",

FontFormats			: "Arrunta;Formateatua;Helbidea;Izenburua 1;Izenburua 2;Izenburua 3;Izenburua 4;Izenburua 5;Izenburua 6;Paragrafoa (DIV)",

// Alerts and Messages
ProcessingXHTML		: "XHTML Prozesatzen. Itxaron mesedez...",
Done				: "Eginda",
PasteWordConfirm	: "Itsatsi nahi duzun textua Wordetik hartua dela dirudi. Itsatsi baino lehen garbitu nahi duzu?",
NotCompatiblePaste	: "Komando hau Internet Explorer 5.5 bertsiorako edo ondorengoentzako erabilgarria dago. Garbitu gabe itsatsi nahi duzu?",
UnknownToolbarItem	: "Ataza barrako elementu ezezaguna \"%1\"",
UnknownCommand		: "Komando izen ezezaguna \"%1\"",
NotImplemented		: "Komando ez inplementatua",
UnknownToolbarSet	: "Ataza barra \"%1\" taldea ez da existitzen",

// Dialogs
DlgBtnOK			: "Ados",
DlgBtnCancel		: "Utzi",
DlgBtnClose			: "Itxi",
DlgBtnBrowseServer	: "Zerbitzaria arakatu",
DlgAdvancedTag		: "Aurreratua",
DlgOpOther			: "&lt;Bestelakoak&gt;",
DlgInfoTab			: "Informazioa",
DlgAlertUrl			: "Mesedez URLa idatzi ezazu",

// General Dialogs Labels
DlgGenNotSet		: "&lt;Ezarri gabe&gt;",
DlgGenId			: "Id",
DlgGenLangDir		: "Hizkuntzaren Norabidea",
DlgGenLangDirLtr	: "Ezkerretik Eskumara(LTR)",
DlgGenLangDirRtl	: "Eskumatik Ezkerrera (RTL)",
DlgGenLangCode		: "Hizkuntza Kodea",
DlgGenAccessKey		: "Sarbide-gakoa",
DlgGenName			: "Izena",
DlgGenTabIndex		: "Tabulazio Indizea",
DlgGenLongDescr		: "URL Deskribapen Luzea",
DlgGenClass			: "Estilo-orriko Klaseak",
DlgGenTitle			: "Izenburua",
DlgGenContType		: "Eduki Mota (Content Type)",
DlgGenLinkCharset	: "Estekatutako Karaktere Multzoa",
DlgGenStyle			: "Estiloa",

// Image Dialog
DlgImgTitle			: "Irudi Ezaugarriak",
DlgImgInfoTab		: "Irudi informazioa",
DlgImgBtnUpload		: "Zerbitzarira bidalia",
DlgImgURL			: "URL",
DlgImgUpload		: "Gora Kargatu",
DlgImgAlt			: "Textu Alternatiboa",
DlgImgWidth			: "Zabalera",
DlgImgHeight		: "Altuera",
DlgImgLockRatio		: "Erlazioa Blokeatu",
DlgBtnResetSize		: "Tamaina Berrezarri",
DlgImgBorder		: "Ertza",
DlgImgHSpace		: "HSpace",
DlgImgVSpace		: "VSpace",
DlgImgAlign			: "Lerrokatu",
DlgImgAlignLeft		: "Ezkerrera",
DlgImgAlignAbsBottom: "Abs Behean",
DlgImgAlignAbsMiddle: "Abs Erdian",
DlgImgAlignBaseline	: "Oinan",
DlgImgAlignBottom	: "Behean",
DlgImgAlignMiddle	: "Erdian",
DlgImgAlignRight	: "Eskuman",
DlgImgAlignTextTop	: "Testua Goian",
DlgImgAlignTop		: "Goian",
DlgImgPreview		: "Aurrebista",
DlgImgAlertUrl		: "Mesedez Irudiaren URLa idatzi",
DlgImgLinkTab		: "Esteka",

// Flash Dialog
DlgFlashTitle		: "Flasharen Ezaugarriak",
DlgFlashChkPlay		: "Automatikoki Erreproduzitu",
DlgFlashChkLoop		: "Begizta",
DlgFlashChkMenu		: "Flasharen Menua Gaitu",
DlgFlashScale		: "Eskalatu",
DlgFlashScaleAll	: "Dena erakutsi",
DlgFlashScaleNoBorder	: "Ertzarik gabe",
DlgFlashScaleFit	: "Doitu",

// Link Dialog
DlgLnkWindowTitle	: "Esteka",
DlgLnkInfoTab		: "Estekaren Informazioa",
DlgLnkTargetTab		: "Helburua",

DlgLnkType			: "Esteka Mota",
DlgLnkTypeURL		: "URL",
DlgLnkTypeAnchor	: "Aingura horrialde honentan",
DlgLnkTypeEMail		: "ePosta",
DlgLnkProto			: "Protokoloa",
DlgLnkProtoOther	: "&lt;Beste batzuk&gt;",
DlgLnkURL			: "URL",
DlgLnkAnchorSel		: "Aingura bat hautatu",
DlgLnkAnchorByName	: "Aingura izenagatik",
DlgLnkAnchorById	: "Elementuaren ID-gatik",
DlgLnkNoAnchors		: "&lt;Ez daude aingurak eskuragarri dokumentuan&gt;",
DlgLnkEMail			: "ePosta Helbidea",
DlgLnkEMailSubject	: "Mezuaren Gaia",
DlgLnkEMailBody		: "Mezuaren Gorputza",
DlgLnkUpload		: "Gora kargatu",
DlgLnkBtnUpload		: "Zerbitzarira bidali",

DlgLnkTarget		: "Target (Helburua)",
DlgLnkTargetFrame	: "&lt;marko&gt;",
DlgLnkTargetPopup	: "&lt;popup lehioa&gt;",
DlgLnkTargetBlank	: "Lehio Berria (_blank)",
DlgLnkTargetParent	: "Lehio Gurasoa (_parent)",
DlgLnkTargetSelf	: "Lehio Berdina (_self)",
DlgLnkTargetTop		: "Goiko Lehioa (_top)",
DlgLnkTargetFrameName	: "Marko Helburuaren Izena",
DlgLnkPopWinName	: "Popup Lehioaren Izena",
DlgLnkPopWinFeat	: "Popup Lehioaren Ezaugarriak",
DlgLnkPopResize		: "Tamaina Aldakorra",
DlgLnkPopLocation	: "Kokaleku Barra",
DlgLnkPopMenu		: "Menu Barra",
DlgLnkPopScroll		: "Korritze Barrak",
DlgLnkPopStatus		: "Egoera Barra",
DlgLnkPopToolbar	: "Tresna Barra",
DlgLnkPopFullScrn	: "Pantaila Osoa (IE)",
DlgLnkPopDependent	: "Menpekoa (Netscape)",
DlgLnkPopWidth		: "Zabalera",
DlgLnkPopHeight		: "Altuera",
DlgLnkPopLeft		: "Ezkerreko  Posizioa",
DlgLnkPopTop		: "Goiko Posizioa",

DlnLnkMsgNoUrl		: "Mesedez URL esteka idatzi",
DlnLnkMsgNoEMail	: "Mesedez ePosta helbidea idatzi",
DlnLnkMsgNoAnchor	: "Mesedez aingura bat aukeratu",

// Color Dialog
DlgColorTitle		: "Kolore Aukeraketa",
DlgColorBtnClear	: "Garbitu",
DlgColorHighlight	: "Nabarmendu",
DlgColorSelected	: "Aukeratuta",

// Smiley Dialog
DlgSmileyTitle		: "Aurpegiera Sartu",

// Special Character Dialog
DlgSpecialCharTitle	: "Karaktere Berezia Aukeratu",

// Table Dialog
DlgTableTitle		: "Taularen Ezaugarriak",
DlgTableRows		: "Lerroak",
DlgTableColumns		: "Zutabeak",
DlgTableBorder		: "Ertzaren Zabalera",
DlgTableAlign		: "Lerrokatu",
DlgTableAlignNotSet	: "<Ezarri gabe>",
DlgTableAlignLeft	: "Ezkerrean",
DlgTableAlignCenter	: "Erdian",
DlgTableAlignRight	: "Eskuman",
DlgTableWidth		: "Zabalera",
DlgTableWidthPx		: "pixel",
DlgTableWidthPc		: "ehuneko",
DlgTableHeight		: "Altuera",
DlgTableCellSpace	: "Gelaxka arteko tartea",
DlgTableCellPad		: "Gelaxken betegarria",
DlgTableCaption		: "Epigrafea",

// Table Cell Dialog
DlgCellTitle		: "Gelaxken Ezaugarriak",
DlgCellWidth		: "Zabalera",
DlgCellWidthPx		: "pixel",
DlgCellWidthPc		: "ehuneko",
DlgCellHeight		: "Altuera",
DlgCellWordWrap		: "Itzulbira",
DlgCellWordWrapNotSet	: "&lt;Ezarri gabe&gt;",
DlgCellWordWrapYes	: "Bai",
DlgCellWordWrapNo	: "Ez",
DlgCellHorAlign		: "Horizontal Alignment",
DlgCellHorAlignNotSet	: "&lt;Ezarri gabe&gt;",
DlgCellHorAlignLeft	: "Ezkerrean",
DlgCellHorAlignCenter	: "Erdian",
DlgCellHorAlignRight: "Eskuman",
DlgCellVerAlign		: "Lerrokatu Bertikalki",
DlgCellVerAlignNotSet	: "&lt;Ezarri gabe&gt;",
DlgCellVerAlignTop	: "Goian",
DlgCellVerAlignMiddle	: "Erdian",
DlgCellVerAlignBottom	: "Behean",
DlgCellVerAlignBaseline	: "Oinan",
DlgCellRowSpan		: "Lerroak Hedatu",
DlgCellCollSpan		: "Zutabeak Hedatu",
DlgCellBackColor	: "Atzeko Kolorea",
DlgCellBorderColor	: "Ertzako Kolorea",
DlgCellBtnSelect	: "Aukertau...",

// Find Dialog
DlgFindTitle		: "Bilaketa",
DlgFindFindBtn		: "Bilatu",
DlgFindNotFoundMsg	: "Idatzitako testua ez da topatu.",

// Replace Dialog
DlgReplaceTitle			: "Ordeztu",
DlgReplaceFindLbl		: "Zer bilatu:",
DlgReplaceReplaceLbl	: "Zerekin ordeztu:",
DlgReplaceCaseChk		: "Maiuskula/minuskula",
DlgReplaceReplaceBtn	: "Ordeztu",
DlgReplaceReplAllBtn	: "Ordeztu Guztiak",
DlgReplaceWordChk		: "Esaldi osoa bilatu",

// Paste Operations / Dialog
PasteErrorPaste	: "Zure web nabigatzailearen segurtasun ezarpenak testuak automatikoki itsastea ez dute baimentzen. Mesedez teklatua erabili ezazu (Ctrl+V).",
PasteErrorCut	: "Zure web nabigatzailearen segurtasun ezarpenak testuak automatikoki moztea ez dute baimentzen. Mesedez teklatua erabili ezazu (Ctrl+X).",
PasteErrorCopy	: "Zure web nabigatzailearen segurtasun ezarpenak testuak automatikoki kopiatzea ez dute baimentzen. Mesedez teklatua erabili ezazu (Ctrl+C).",

PasteAsText		: "Testu Arrunta bezala Itsatsi",
PasteFromWord	: "Word-etik itsatsi",

DlgPasteMsg2	: "Mesedez teklatua erabilita (<STRONG>Ctrl+V</STRONG>) ondorego eremuan testua itsatsi eta <STRONG>OK</STRONG> sakatu.",
DlgPasteIgnoreFont		: "Letra Motaren definizioa ezikusi",
DlgPasteRemoveStyles	: "Estilo definizioak kendu",
DlgPasteCleanBox		: "Testu-eremua Garbitu",


// Color Picker
ColorAutomatic	: "Automatikoa",
ColorMoreColors	: "Kolore gehiago...",

// Document Properties
DocProps		: "Dokumentuaren Ezarpenak",

// Anchor Dialog
DlgAnchorTitle		: "Ainguraren Ezaugarriak",
DlgAnchorName		: "Ainguraren Izena",
DlgAnchorErrorName	: "Idatzi ainguraren izena",

// Speller Pages Dialog
DlgSpellNotInDic		: "Ez dago hiztegian",
DlgSpellChangeTo		: "Honekin ordezkatu",
DlgSpellBtnIgnore		: "Ezikusi",
DlgSpellBtnIgnoreAll	: "Denak Ezikusi",
DlgSpellBtnReplace		: "Ordezkatu",
DlgSpellBtnReplaceAll	: "Denak Ordezkatu",
DlgSpellBtnUndo			: "Desegin",
DlgSpellNoSuggestions	: "- Iradokizunik ez -",
DlgSpellProgress		: "Zuzenketa ortografikoa martxan...",
DlgSpellNoMispell		: "Zuzenketa ortografikoa bukatuta: Akatsik ez",
DlgSpellNoChanges		: "Zuzenketa ortografikoa bukatuta: Ez da ezer aldatu",
DlgSpellOneChange		: "Zuzenketa ortografikoa bukatuta: Hitz bat aldatu da",
DlgSpellManyChanges		: "Zuzenketa ortografikoa bukatuta: %1 hitz aldatu dira",

IeSpellDownload			: "Zuzentzaile ortografikoa ez dago instalatuta. Deskargatu nahi duzu?",

// Button Dialog
DlgButtonText	: "Testua (Balorea)",
DlgButtonType	: "Mota",

// Checkbox and Radio Button Dialogs
DlgCheckboxName		: "Izena",
DlgCheckboxValue	: "Balorea",
DlgCheckboxSelected	: "Hautatuta",

// Form Dialog
DlgFormName		: "Izena",
DlgFormAction	: "Ekintza",
DlgFormMethod	: "Method",

// Select Field Dialog
DlgSelectName		: "Izena",
DlgSelectValue		: "Balorea",
DlgSelectSize		: "Tamaina",
DlgSelectLines		: "lerro kopurura",
DlgSelectChkMulti	: "Hautaketa anitzak baimendu",
DlgSelectOpAvail	: "Aukera Eskuragarriak",
DlgSelectOpText		: "Testua",
DlgSelectOpValue	: "Balorea",
DlgSelectBtnAdd		: "Gehitu",
DlgSelectBtnModify	: "Aldatu",
DlgSelectBtnUp		: "Gora",
DlgSelectBtnDown	: "Behera",
DlgSelectBtnSetValue : "Aukeratutako balorea ezarri",
DlgSelectBtnDelete	: "Ezabatu",

// Textarea Dialog
DlgTextareaName	: "Izena",
DlgTextareaCols	: "Zutabeak",
DlgTextareaRows	: "Lerroak",

// TextField Dialog
DlgTextName			: "Izena",
DlgTextValue		: "Balorea",
DlgTextCharWidth	: "Zabalera",
DlgTextMaxChars		: "Zenbat karaktere gehienez",
DlgTextType			: "Mota",
DlgTextTypeText		: "Testua",
DlgTextTypePass		: "Pasahitza",

// Hidden Field Dialog
DlgHiddenName	: "Izena",
DlgHiddenValue	: "Balorea",

// Bulleted List Dialog
BulletedListProp	: "Buletdun Zerrendaren Ezarpenak",
NumberedListProp	: "Zenbakidun Zerrendaren Ezarpenak",
DlgLstType			: "Mota",
DlgLstTypeCircle	: "Zirkulua",
DlgLstTypeDisk		: "Diskoa",
DlgLstTypeSquare	: "Karratua",
DlgLstTypeNumbers	: "Zenbakiak (1, 2, 3)",
DlgLstTypeLCase		: "Letra xeheak (a, b, c)",
DlgLstTypeUCase		: "Letra larriak (A, B, C)",
DlgLstTypeSRoman	: "Erromatar zenbaki zeheak (i, ii, iii)",
DlgLstTypeLRoman	: "Erromatar zenbaki larriak (I, II, III)",

// Document Properties Dialog
DlgDocGeneralTab	: "Orokorra",
DlgDocBackTab		: "Atzekaldea",
DlgDocColorsTab		: "Koloreak eta Marjinak",
DlgDocMetaTab		: "Meta Informazioa",

DlgDocPageTitle		: "Orriaren Izenburua",
DlgDocLangDir		: "Hizkuntzaren Norabidea",
DlgDocLangDirLTR	: "Ezkerretik eskumara (LTR)",
DlgDocLangDirRTL	: "Eskumatik ezkerrera (RTL)",
DlgDocLangCode		: "Hizkuntzaren Kodea",
DlgDocCharSet		: "Karaktere Multzoaren Kodeketa",
DlgDocCharSetOther	: "Beste Karaktere Multzoaren Kodeketa",

DlgDocDocType		: "Document Type Goiburua",
DlgDocDocTypeOther	: "Beste Document Type Goiburua",
DlgDocIncXHTML		: "XHTML Ezarpenak",
DlgDocBgColor		: "Atzeko Kolorea",
DlgDocBgImage		: "Atzeko Irudiaren URL-a",
DlgDocBgNoScroll	: "Korritze gabeko Atzekaldea",
DlgDocCText			: "Testua",
DlgDocCLink			: "Estekak",
DlgDocCVisited		: "Bisitatutako Estekak",
DlgDocCActive		: "Esteka Aktiboa",
DlgDocMargins		: "Orrialdearen marjinak",
DlgDocMaTop			: "Goian",
DlgDocMaLeft		: "Ezkerrean",
DlgDocMaRight		: "Eskuman",
DlgDocMaBottom		: "Behean",
DlgDocMeIndex		: "Dokumentuaren Gako-hitzak (komarekin bananduta)",
DlgDocMeDescr		: "Dokumentuaren Deskribapena",
DlgDocMeAuthor		: "Egilea",
DlgDocMeCopy		: "Copyright",
DlgDocPreview		: "Aurrebista",

// Templates Dialog
Templates			: "Txantiloiak",
DlgTemplatesTitle	: "Eduki Txantiloiak",
DlgTemplatesSelMsg	: "Mesedez txantiloia aukeratu editorean kargatzeko<br>(orain dauden edukiak galduko dira):",
DlgTemplatesLoading	: "Txantiloiak kargatzen. Itxaron mesedez...",
DlgTemplatesNoTpl	: "(Ez dago definitutako txantiloirik)",

// About Dialog
DlgAboutAboutTab	: "Honi buruz",
DlgAboutBrowserInfoTab	: "Nabigatzailearen Informazioa",
DlgAboutVersion		: "bertsioa",
DlgAboutLicense		: "GNU Lesser General Public License Lizentziapean",
DlgAboutInfo		: "Informazio gehiago eskuratzeko hona joan"
}