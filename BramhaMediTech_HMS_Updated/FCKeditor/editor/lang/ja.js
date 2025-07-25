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
 * File Name: ja.js
 * 	Japanese language file.
 * 
 * File Authors:
 * 		Takashi Yamaguchi (jack@omakase.net)
 */

var FCKLang =
{
// Language direction : "ltr" (left to right) or "rtl" (right to left).
Dir					: "ltr",

ToolbarCollapse		: "ツールバーを隠す",
ToolbarExpand		: "ツールバーを表示",

// Toolbar Items and Context Menu
Save				: "保存",
NewPage				: "新しいページ",
Preview				: "プレビュー",
Cut					: "切り取り",
Copy				: "コピー",
Paste				: "貼り付け",
PasteText			: "プレーンテキスト貼り付け",
PasteWord			: "ワード文章から貼り付け",
Print				: "印刷",
SelectAll			: "すべて選択",
RemoveFormat		: "フォーマット削除",
InsertLinkLbl		: "リンク",
InsertLink			: "リンク挿入/編集",
RemoveLink			: "リンク削除",
Anchor				: "アンカー挿入/編集",
InsertImageLbl		: "イメージ",
InsertImage			: "イメージ挿入/編集",
InsertFlashLbl		: "Flash",
InsertFlash			: "Flash挿入/編集",
InsertTableLbl		: "テーブル",
InsertTable			: "テーブル挿入/編集",
InsertLineLbl		: "ライン",
InsertLine			: "横罫線",
InsertSpecialCharLbl: "特殊文字",
InsertSpecialChar	: "特殊文字挿入",
InsertSmileyLbl		: "絵文字",
InsertSmiley		: "絵文字挿入",
About				: "FCKeditorヘルプ",
Bold				: "太字",
Italic				: "斜体",
Underline			: "下線",
StrikeThrough		: "打ち消し線",
Subscript			: "添え字",
Superscript			: "上付き文字",
LeftJustify			: "左揃え",
CenterJustify		: "中央揃え",
RightJustify		: "右揃え",
BlockJustify		: "両端揃え",
DecreaseIndent		: "インデント解除",
IncreaseIndent		: "インデント",
Undo				: "元に戻す",
Redo				: "やり直し",
NumberedListLbl		: "段落番号",
NumberedList		: "段落番号の追加/削除",
BulletedListLbl		: "箇条書き",
BulletedList		: "箇条書きの追加/削除",
ShowTableBorders	: "テーブルボーダー表示",
ShowDetails			: "詳細表示",
Style				: "スタイル",
FontFormat			: "フォーマット",
Font				: "フォント",
FontSize			: "サイズ",
TextColor			: "テキスト色",
BGColor				: "背景色",
Source				: "ソース",
Find				: "検索",
Replace				: "置き換え",
SpellCheck			: "スペルチェック",
UniversalKeyboard	: "ユニバーサル・キーボード",

Form			: "フォーム",
Checkbox		: "チェックボックス",
RadioButton		: "ラジオボタン",
TextField		: "１行テキスト",
Textarea		: "テキストエリア",
HiddenField		: "不可視フィールド",
Button			: "ボタン",
SelectionField	: "選択フィールド",
ImageButton		: "画像ボタン",

// Context Menu
EditLink			: "リンク編集",
InsertRow			: "行挿入",
DeleteRows			: "行削除",
InsertColumn		: "列挿入",
DeleteColumns		: "列削除",
InsertCell			: "セル挿入",
DeleteCells			: "セル削除",
MergeCells			: "セル結合",
SplitCell			: "セル分割",
CellProperties		: "セル プロパティ",
TableProperties		: "テーブル プロパティ",
ImageProperties		: "イメージ プロパティ",
FlashProperties		: "Flash プロパティ",

AnchorProp			: "アンカー プロパティ",
ButtonProp			: "ボタン プロパティ",
CheckboxProp		: "チェックボックス プロパティ",
HiddenFieldProp		: "不可視フィールド プロパティ",
RadioButtonProp		: "ラジオボタン プロパティ",
ImageButtonProp		: "画像ボタン プロパティ",
TextFieldProp		: "１行テキスト プロパティ",
SelectionFieldProp	: "選択フィールド プロパティ",
TextareaProp		: "テキストエリア プロパティ",
FormProp			: "フォーム プロパティ",

FontFormats			: "Normal;Formatted;Address;Heading 1;Heading 2;Heading 3;Heading 4;Heading 5;Heading 6;Paragraph (DIV)",

// Alerts and Messages
ProcessingXHTML		: "XHTML処理中. しばらくお待ちください...",
Done				: "完了",
PasteWordConfirm	: "貼り付けを行うテキストは、ワード文章からコピーされようとしています。貼り付ける前にクリーニングを行いますか？",
NotCompatiblePaste	: "このコマンドはインターネット・エクスプローラーバージョン5.5以上で利用可能です。クリーニングしないで貼り付けを行いますか？",
UnknownToolbarItem	: "未知のツールバー項目 \"%1\"",
UnknownCommand		: "未知のコマンド名 \"%1\"",
NotImplemented		: "コマンドはインプリメントされませんでした。",
UnknownToolbarSet	: "ツールバー設定 \"%1\" 存在しません。",

// Dialogs
DlgBtnOK			: "OK",
DlgBtnCancel		: "キャンセル",
DlgBtnClose			: "閉じる",
DlgBtnBrowseServer	: "サーバーブラウザー",
DlgAdvancedTag		: "高度な設定",
DlgOpOther			: "&lt;その他&gt;",
DlgInfoTab			: "情報",
DlgAlertUrl			: "URLを挿入してください",

// General Dialogs Labels
DlgGenNotSet		: "&lt;なし&gt;",
DlgGenId			: "Id",
DlgGenLangDir		: "文字表記の方向",
DlgGenLangDirLtr	: "左から右 (LTR)",
DlgGenLangDirRtl	: "右から左 (RTL)",
DlgGenLangCode		: "言語コード",
DlgGenAccessKey		: "アクセスキー",
DlgGenName			: "Name属性",
DlgGenTabIndex		: "タブインデックス",
DlgGenLongDescr		: "longdesc属性(長文説明)",
DlgGenClass			: "スタイルシートクラス",
DlgGenTitle			: "Title属性",
DlgGenContType		: "Content Type属性",
DlgGenLinkCharset	: "リンクcharset属性",
DlgGenStyle			: "スタイルシート",

// Image Dialog
DlgImgTitle			: "イメージ プロパティ",
DlgImgInfoTab		: "イメージ 情報",
DlgImgBtnUpload		: "サーバーに送信",
DlgImgURL			: "URL",
DlgImgUpload		: "アップロード",
DlgImgAlt			: "代替テキスト",
DlgImgWidth			: "幅",
DlgImgHeight		: "高さ",
DlgImgLockRatio		: "ロック比率",
DlgBtnResetSize		: "サイズリセット",
DlgImgBorder		: "ボーダー",
DlgImgHSpace		: "横間隔",
DlgImgVSpace		: "縦間隔",
DlgImgAlign			: "行揃え",
DlgImgAlignLeft		: "左",
DlgImgAlignAbsBottom: "下部(絶対的)",
DlgImgAlignAbsMiddle: "中央(絶対的)",
DlgImgAlignBaseline	: "ベースライン",
DlgImgAlignBottom	: "下",
DlgImgAlignMiddle	: "中央",
DlgImgAlignRight	: "右",
DlgImgAlignTextTop	: "テキスト上部",
DlgImgAlignTop		: "上",
DlgImgPreview		: "プレビュー",
DlgImgAlertUrl		: "イメージのURLを入力してください。",
DlgImgLinkTab		: "リンク",

// Flash Dialog
DlgFlashTitle		: "Flash プロパティ",
DlgFlashChkPlay		: "再生",
DlgFlashChkLoop		: "ループ再生",
DlgFlashChkMenu		: "Flashメニュー可能",
DlgFlashScale		: "拡大縮小設定",
DlgFlashScaleAll	: "すべて表示",
DlgFlashScaleNoBorder	: "外が見えない様に拡大",
DlgFlashScaleFit	: "上下左右にフィット",

// Link Dialog
DlgLnkWindowTitle	: "ハイパーリンク",
DlgLnkInfoTab		: "ハイパーリンク 情報",
DlgLnkTargetTab		: "ターゲット",

DlgLnkType			: "リンクタイプ",
DlgLnkTypeURL		: "URL",
DlgLnkTypeAnchor	: "このページのアンカー",
DlgLnkTypeEMail		: "E-Mail",
DlgLnkProto			: "プロトコル",
DlgLnkProtoOther	: "&lt;その他&gt;",
DlgLnkURL			: "URL",
DlgLnkAnchorSel		: "アンカーを選択",
DlgLnkAnchorByName	: "アンカー名",
DlgLnkAnchorById	: "エレメントID",
DlgLnkNoAnchors		: "&lt;ドキュメントにおいて利用可能なアンカーはありません。&gt;",
DlgLnkEMail			: "E-Mail アドレス",
DlgLnkEMailSubject	: "件名",
DlgLnkEMailBody		: "本文",
DlgLnkUpload		: "アップロード",
DlgLnkBtnUpload		: "サーバーに送信",

DlgLnkTarget		: "ターゲット",
DlgLnkTargetFrame	: "&lt;フレーム&gt;",
DlgLnkTargetPopup	: "&lt;ポップアップウィンドウ&gt;",
DlgLnkTargetBlank	: "新しいウィンドウ (_blank)",
DlgLnkTargetParent	: "親ウィンドウ (_parent)",
DlgLnkTargetSelf	: "同じウィンドウ (_self)",
DlgLnkTargetTop		: "最上位ウィンドウ (_top)",
DlgLnkTargetFrameName	: "目的のフレーム名",
DlgLnkPopWinName	: "ポップアップウィンドウ名",
DlgLnkPopWinFeat	: "ポップアップウィンドウ特徴",
DlgLnkPopResize		: "リサイズ可能",
DlgLnkPopLocation	: "ロケーションバー",
DlgLnkPopMenu		: "メニューバー",
DlgLnkPopScroll		: "スクロールバー",
DlgLnkPopStatus		: "ステータスバー",
DlgLnkPopToolbar	: "ツールバー",
DlgLnkPopFullScrn	: "全画面モード(IE)",
DlgLnkPopDependent	: "開いたウィンドウに連動して閉じる (Netscape)",
DlgLnkPopWidth		: "幅",
DlgLnkPopHeight		: "高さ",
DlgLnkPopLeft		: "左端からの座標で指定",
DlgLnkPopTop		: "上端からの座標で指定",

DlnLnkMsgNoUrl		: "リンクURLを入力してください。",
DlnLnkMsgNoEMail	: "メールアドレスを入力してください。",
DlnLnkMsgNoAnchor	: "アンカーを選択してください。",

// Color Dialog
DlgColorTitle		: "色選択",
DlgColorBtnClear	: "クリア",
DlgColorHighlight	: "ハイライト",
DlgColorSelected	: "選択色",

// Smiley Dialog
DlgSmileyTitle		: "顔文字挿入",

// Special Character Dialog
DlgSpecialCharTitle	: "特殊文字選択",

// Table Dialog
DlgTableTitle		: "テーブル プロパティ",
DlgTableRows		: "行",
DlgTableColumns		: "列",
DlgTableBorder		: "ボーダーサイズ",
DlgTableAlign		: "キャプションの整列",
DlgTableAlignNotSet	: "<なし>",
DlgTableAlignLeft	: "左",
DlgTableAlignCenter	: "中央",
DlgTableAlignRight	: "右",
DlgTableWidth		: "テーブル幅",
DlgTableWidthPx		: "ピクセル",
DlgTableWidthPc		: "パーセント",
DlgTableHeight		: "テーブル高さ",
DlgTableCellSpace	: "セル内余白",
DlgTableCellPad		: "セル内間隔",
DlgTableCaption		: "ｷｬﾌﾟｼｮﾝ",

// Table Cell Dialog
DlgCellTitle		: "セル プロパティ",
DlgCellWidth		: "幅",
DlgCellWidthPx		: "ピクセル",
DlgCellWidthPc		: "パーセント",
DlgCellHeight		: "高さ",
DlgCellWordWrap		: "折り返し",
DlgCellWordWrapNotSet	: "&lt;なし&gt;",
DlgCellWordWrapYes	: "Yes",
DlgCellWordWrapNo	: "No",
DlgCellHorAlign		: "セル横の整列",
DlgCellHorAlignNotSet	: "&lt;なし&gt;",
DlgCellHorAlignLeft	: "左",
DlgCellHorAlignCenter	: "中央",
DlgCellHorAlignRight: "右",
DlgCellVerAlign		: "セル縦の整列",
DlgCellVerAlignNotSet	: "&lt;なし&gt;",
DlgCellVerAlignTop	: "上",
DlgCellVerAlignMiddle	: "中央",
DlgCellVerAlignBottom	: "下",
DlgCellVerAlignBaseline	: "ベースライン",
DlgCellRowSpan		: "縦幅(行数)",
DlgCellCollSpan		: "横幅(列数)",
DlgCellBackColor	: "背景色",
DlgCellBorderColor	: "ボーダーカラー",
DlgCellBtnSelect	: "選択...",

// Find Dialog
DlgFindTitle		: "検索",
DlgFindFindBtn		: "検索",
DlgFindNotFoundMsg	: "指定された文字列は見つかりませんでした。",

// Replace Dialog
DlgReplaceTitle			: "置き換え",
DlgReplaceFindLbl		: "検索する文字列:",
DlgReplaceReplaceLbl	: "置換えする文字列:",
DlgReplaceCaseChk		: "部分一致",
DlgReplaceReplaceBtn	: "置換え",
DlgReplaceReplAllBtn	: "すべて置換え",
DlgReplaceWordChk		: "単語単位で一致",

// Paste Operations / Dialog
PasteErrorPaste	: "ブラウザーのセキュリティ設定によりエディタの貼り付け操作が自動で実行することができません。実行するには手動でキーボードの(Ctrl+V)を使用してください。",
PasteErrorCut	: "ブラウザーのセキュリティ設定によりエディタの切り取り操作が自動で実行することができません。実行するには手動でキーボードの(Ctrl+X)を使用してください。",
PasteErrorCopy	: "ブラウザーのセキュリティ設定によりエディタのコピー操作が自動で実行することができません。実行するには手動でキーボードの(Ctrl+C)を使用してください。",

PasteAsText		: "プレーンテキスト貼り付け",
PasteFromWord	: "ワード文章から貼り付け",

DlgPasteMsg2	: "キーボード(<STRONG>Ctrl+V</STRONG>)を使用して、次の入力エリア内で貼って、<STRONG>OK</STRONG>を押してください。",
DlgPasteIgnoreFont		: "FontタグのFace属性を無視します。",
DlgPasteRemoveStyles	: "スタイル定義を削除します。",
DlgPasteCleanBox		: "入力エリアクリア",


// Color Picker
ColorAutomatic	: "自動",
ColorMoreColors	: "その他の色...",

// Document Properties
DocProps		: "文書 プロパティ",

// Anchor Dialog
DlgAnchorTitle		: "アンカー プロパティ",
DlgAnchorName		: "アンカー名",
DlgAnchorErrorName	: "アンカー名を必ず入力してください。",

// Speller Pages Dialog
DlgSpellNotInDic		: "辞書にありません",
DlgSpellChangeTo		: "変更",
DlgSpellBtnIgnore		: "無視",
DlgSpellBtnIgnoreAll	: "すべて無視",
DlgSpellBtnReplace		: "置換",
DlgSpellBtnReplaceAll	: "すべて置換",
DlgSpellBtnUndo			: "やり直し",
DlgSpellNoSuggestions	: "- 該当なし -",
DlgSpellProgress		: "スペルチェック処理中...",
DlgSpellNoMispell		: "スペルチェック完了: スペルの誤りはありませんでした",
DlgSpellNoChanges		: "スペルチェック完了: 語句は変更されませんでした",
DlgSpellOneChange		: "スペルチェック完了: １語句変更されました",
DlgSpellManyChanges		: "スペルチェック完了: %1 語句変更されました",

IeSpellDownload			: "スペルチェッカーがインストールされていません。今すぐダウンロードしますか?",

// Button Dialog
DlgButtonText	: "テキスト (値)",
DlgButtonType	: "タイプ",

// Checkbox and Radio Button Dialogs
DlgCheckboxName		: "名前",
DlgCheckboxValue	: "値",
DlgCheckboxSelected	: "選択済み",

// Form Dialog
DlgFormName		: "フォーム名",
DlgFormAction	: "アクション",
DlgFormMethod	: "メソッド",

// Select Field Dialog
DlgSelectName		: "名前",
DlgSelectValue		: "値",
DlgSelectSize		: "サイズ",
DlgSelectLines		: "行",
DlgSelectChkMulti	: "複数項目選択を許可",
DlgSelectOpAvail	: "利用可能なオプション",
DlgSelectOpText		: "選択項目名",
DlgSelectOpValue	: "選択項目値",
DlgSelectBtnAdd		: "追加",
DlgSelectBtnModify	: "編集",
DlgSelectBtnUp		: "上へ",
DlgSelectBtnDown	: "下へ",
DlgSelectBtnSetValue : "選択した値を設定",
DlgSelectBtnDelete	: "削除",

// Textarea Dialog
DlgTextareaName	: "名前",
DlgTextareaCols	: "列",
DlgTextareaRows	: "行",

// TextField Dialog
DlgTextName			: "名前",
DlgTextValue		: "値",
DlgTextCharWidth	: "サイズ",
DlgTextMaxChars		: "最大長",
DlgTextType			: "タイプ",
DlgTextTypeText		: "テキスト",
DlgTextTypePass		: "パスワード入力",

// Hidden Field Dialog
DlgHiddenName	: "名前",
DlgHiddenValue	: "値",

// Bulleted List Dialog
BulletedListProp	: "箇条書き プロパティ",
NumberedListProp	: "段落番号 プロパティ",
DlgLstType			: "タイプ",
DlgLstTypeCircle	: "白丸",
DlgLstTypeDisk		: "黒丸",
DlgLstTypeSquare	: "四角",
DlgLstTypeNumbers	: "アラビア数字 (1, 2, 3)",
DlgLstTypeLCase		: "英字小文字 (a, b, c)",
DlgLstTypeUCase		: "英字大文字 (A, B, C)",
DlgLstTypeSRoman	: "ローマ数字小文字 (i, ii, iii)",
DlgLstTypeLRoman	: "ローマ数字大文字 (I, II, III)",

// Document Properties Dialog
DlgDocGeneralTab	: "全般",
DlgDocBackTab		: "背景",
DlgDocColorsTab		: "色とマージン",
DlgDocMetaTab		: "メタデータ",

DlgDocPageTitle		: "ページタイトル",
DlgDocLangDir		: "言語文字表記の方向",
DlgDocLangDirLTR	: "左から右に文字表記します(LTR)",
DlgDocLangDirRTL	: "右から左に文字表記します(RTL)",
DlgDocLangCode		: "言語コード",
DlgDocCharSet		: "文字セット符号化",
DlgDocCharSetOther	: "他の文字セット符号化",

DlgDocDocType		: "文書タイプヘッダー",
DlgDocDocTypeOther	: "その他文書タイプヘッダー",
DlgDocIncXHTML		: "XHTML宣言をインクルード",
DlgDocBgColor		: "背景色",
DlgDocBgImage		: "背景画像 URL",
DlgDocBgNoScroll	: "スクロールしない背景",
DlgDocCText			: "テキスト",
DlgDocCLink			: "リンク",
DlgDocCVisited		: "アクセス済みリンク",
DlgDocCActive		: "アクセス中リンク",
DlgDocMargins		: "ページ・マージン",
DlgDocMaTop			: "上部",
DlgDocMaLeft		: "左",
DlgDocMaRight		: "右",
DlgDocMaBottom		: "下部",
DlgDocMeIndex		: "文書のキーワード(カンマ区切り)",
DlgDocMeDescr		: "文書の概要",
DlgDocMeAuthor		: "文書の作者",
DlgDocMeCopy		: "文書の著作権",
DlgDocPreview		: "プレビュー",

// Templates Dialog
Templates			: "テンプレート(雛形)",
DlgTemplatesTitle	: "テンプレート内容",
DlgTemplatesSelMsg	: "エディターで使用するテンプレートを選択してください。<br>(現在のエディタの内容は失われます):",
DlgTemplatesLoading	: "テンプレート一覧読み込み中. しばらくお待ちください...",
DlgTemplatesNoTpl	: "(テンプレートが定義されていません)",

// About Dialog
DlgAboutAboutTab	: "バージョン情報",
DlgAboutBrowserInfoTab	: "ブラウザ情報",
DlgAboutVersion		: "バージョン",
DlgAboutLicense		: "Licensed under the terms of the GNU Lesser General Public License",
DlgAboutInfo		: "より詳しい情報はこちらで"
}