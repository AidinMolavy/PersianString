using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//[ExecuteInEditMode]
class persian_string : MonoBehaviour 
{
	
	
    const int UNICODE_LETTERS_LENGTH      =  41 ; 
	const int PERSIAN_LETTERS_LENGTH      =  33 ;
	const int SPECIAL_CHAR_START_INDEX    =  33 ;
	const int SPECIAL_CHAR_END_INDEX      =  40 ;
	private enum  _WordType {Persian,Foreign,Special}; 
	
	private struct UnicodeLetter
	{
		public  string UnicodeName;
		public  char[] Letters;
		
		public  char IsolatedForm;
		public  char InitialForm;
		public  char MedialForm;
		public  char FinalForm;
		
		public  char Sticky_InitialForm;
		public  char Sticky_MedialForm;
		public  char Sticky_FinalForm;
		public  char Sticky_Both;
		
		public  MetaDataForWord MetaData; 
				
	}
	private struct MetaDataForWord
	{
		public bool ConvertToPerisan;
		public _WordType WordType;
		
	}
	private struct WordWithMetaData
	{
		public char[] Word;
		public MetaDataForWord MetaData;
	}
	
    #region Public Fields

    #endregion

    #region private Fields 
	
		private UnicodeLetter[]     UniLetters  = new UnicodeLetter[UNICODE_LETTERS_LENGTH];
		//private SpecialCharacter[]  specialChar = new SpecialCharacter[SPECIAL_CHAR_LENGTH];
		
	
    #endregion

    #region Static Fields
	static string a = "";
	
    #endregion

    #region Properties

    #endregion
	
    #region Functions
    void Awake()
    {
		#region Special Chracter
		
		// Full stop
		UniLetters[33].UnicodeName = "Full stop";
		
		UniLetters[33].Letters = new char[1];
		UniLetters[33].Letters[0] = '\u002E';


		UniLetters[33].IsolatedForm = '\u002E';
		UniLetters[33].InitialForm  = '\u002E';
		UniLetters[33].MedialForm   = '\u002E';
		UniLetters[33].FinalForm    = '\u002E';
		
		UniLetters[33].Sticky_InitialForm  = '0';
		UniLetters[33].Sticky_MedialForm   = '0';
		UniLetters[33].Sticky_FinalForm    = '0';
		
		
		// Special Character "Space"
		UniLetters[34].UnicodeName = "Space";
		
		UniLetters[34].Letters = new char[1];
		UniLetters[34].Letters[0] = '\u0020';

		UniLetters[34].IsolatedForm = '\u0020';
		UniLetters[34].InitialForm  = '\u0020';
		UniLetters[34].MedialForm   = '\u0020';
		UniLetters[34].FinalForm    = '\u0020';
		
		UniLetters[34].Sticky_InitialForm  = '0';
		UniLetters[34].Sticky_MedialForm   = '0';
		UniLetters[34].Sticky_FinalForm    = '0';
		
		UniLetters[34].MetaData.ConvertToPerisan = false;
		
		
		
		// Special Character "Question mark"
		UniLetters[35].UnicodeName = "Question mark";
		
		UniLetters[35].Letters = new char[2];
		UniLetters[35].Letters[0] = '\u003F';
		UniLetters[35].Letters[1] = '\u061F';

		UniLetters[35].IsolatedForm = '\u061F';
		UniLetters[35].InitialForm  = '\u061F';
		UniLetters[35].MedialForm   = '\u061F';
		UniLetters[35].FinalForm    = '\u061F';
		
		UniLetters[35].Sticky_InitialForm  = '0';
		UniLetters[35].Sticky_MedialForm   = '0';
		UniLetters[35].Sticky_FinalForm    = '0';
		
		UniLetters[35].MetaData.ConvertToPerisan = true;
		
		
		
		//Exclamation mark
		UniLetters[36].UnicodeName = "Exclamation mark";
		
		UniLetters[36].Letters = new char[1];
		UniLetters[36].Letters[0] = '\u0021';


		UniLetters[36].IsolatedForm = '\u0021';
		UniLetters[36].InitialForm  = '\u0021';
		UniLetters[36].MedialForm   = '\u0021';
		UniLetters[36].FinalForm    = '\u0021';
		
		UniLetters[36].Sticky_InitialForm  = '\u0021';
		UniLetters[36].Sticky_MedialForm   = '\u0021';
		UniLetters[36].Sticky_FinalForm    = '\u0021';
		
		
		//Quotation mark
		UniLetters[37].UnicodeName = "Quotation mark";
		
		UniLetters[37].Letters = new char[1];
		UniLetters[37].Letters[0] = '\u0022';


		UniLetters[37].IsolatedForm = '\u0022';
		UniLetters[37].InitialForm  = '\u0022';
		UniLetters[37].MedialForm   = '\u0022';
		UniLetters[37].FinalForm    = '\u0022';
		
		UniLetters[37].Sticky_InitialForm  = '\u0022';
		UniLetters[37].Sticky_MedialForm   = '\u0022';
		UniLetters[37].Sticky_FinalForm    = '\u0022';
		
		
//		//Left parenthesis
		UniLetters[38].UnicodeName = "Left parenthesis";
		
		UniLetters[38].Letters = new char[2];
		UniLetters[38].Letters[0] = '\u0028';
		UniLetters[38].Letters[1] = '\uFD3E';

		UniLetters[38].IsolatedForm = '\uFD3F';
		UniLetters[38].InitialForm  = '\uFD3F';
		UniLetters[38].MedialForm   = '\uFD3F';
		UniLetters[38].FinalForm    = '\uFD3F';
		
		UniLetters[38].Sticky_InitialForm  = '0';
		UniLetters[38].Sticky_MedialForm   = '0';
		UniLetters[38].Sticky_FinalForm    = '0';
		
		
		
		// Right parenthesis
		UniLetters[39].UnicodeName = "Right parenthesis";
		
		UniLetters[39].Letters = new char[2];
		UniLetters[39].Letters[0] = '\u0029';
		UniLetters[39].Letters[1] = '\uFD3F';

		UniLetters[39].IsolatedForm = '\uFD3E';
		UniLetters[39].InitialForm  = '\uFD3E';
		UniLetters[39].MedialForm   = '\uFD3E';
		UniLetters[39].FinalForm    = '\uFD3E';
		
		UniLetters[39].Sticky_InitialForm  = '0';
		UniLetters[39].Sticky_MedialForm   = '0';
		UniLetters[39].Sticky_FinalForm    = '0';
		
		
		
		// Comma
		UniLetters[40].UnicodeName = "Comma";
		
		UniLetters[40].Letters = new char[1];
		UniLetters[40].Letters[0] = '\u002C';


		UniLetters[40].IsolatedForm = '\u060C';
		UniLetters[40].InitialForm  = '\u060C';
		UniLetters[40].MedialForm   = '\u060C';
		UniLetters[40].FinalForm    = '\u060C';
		
		UniLetters[40].Sticky_InitialForm  = '\u060C';
		UniLetters[40].Sticky_MedialForm   = '\u060C';
    	UniLetters[40].Sticky_FinalForm    = '\u060C';
	    

		
//		//
//		UniLetters[].UnicodeName = "";
//		
//		UniLetters[].Letters = new char[3];
//		UniLetters[].Letters[0] = '\u';
//		UniLetters[].Letters[1] = '\u';
//		UniLetters[].Letters[2] = '\u';
//
//		UniLetters[].IsolatedForm = '\u';
//		UniLetters[].InitialForm  = '\u';
//		UniLetters[].MedialForm   = '\u';
//		UniLetters[].FinalForm    = '\u';
//		
//		UniLetters[].Sticky_InitialForm  = '\u';
//		UniLetters[].Sticky_MedialForm   = '\u';
//    	UniLetters[].Sticky_FinalForm    = '\u';	
//		
//
//		
//		//
//		UniLetters[].UnicodeName = "";
//		
//		UniLetters[].Letters = new char[3];
//		UniLetters[].Letters[0] = '\u';
//		UniLetters[].Letters[1] = '\u';
//		UniLetters[].Letters[2] = '\u';
//
//		UniLetters[].IsolatedForm = '\u';
//		UniLetters[].InitialForm  = '\u';
//		UniLetters[].MedialForm   = '\u';
//		UniLetters[].FinalForm    = '\u';
//		
//		UniLetters[].Sticky_InitialForm  = '\u';
//		UniLetters[].Sticky_MedialForm   = '\u';
//    	UniLetters[].Sticky_FinalForm    = '\u';
//		
//
//		
//		//
//		UniLetters[].UnicodeName = "";
//		
//		UniLetters[].Letters = new char[3];
//		UniLetters[].Letters[0] = '\u';
//		UniLetters[].Letters[1] = '\u';
//		UniLetters[].Letters[2] = '\u';
//
//		UniLetters[].IsolatedForm = '\u';
//		UniLetters[].InitialForm  = '\u';
//		UniLetters[].MedialForm   = '\u';
//		UniLetters[].FinalForm    = '\u';
//		
//		UniLetters[].Sticky_InitialForm  = '\u';
//		UniLetters[].Sticky_MedialForm   = '\u';
//    	UniLetters[].Sticky_FinalForm    = '\u';
//		
//
//		
//		//
//		UniLetters[].UnicodeName = "";
//		
//		UniLetters[].Letters = new char[3];
//		UniLetters[].Letters[0] = '\u';
//		UniLetters[].Letters[1] = '\u';
//		UniLetters[].Letters[2] = '\u';
//
//		UniLetters[].IsolatedForm = '\u';
//		UniLetters[].InitialForm  = '\u';
//		UniLetters[].MedialForm   = '\u';
//		UniLetters[].FinalForm    = '\u';
//		
//		UniLetters[].Sticky_InitialForm  = '\u';
//		UniLetters[].Sticky_MedialForm   = '\u';
//    	UniLetters[].Sticky_FinalForm    = '\u';
		
		
		
		
		
		
		//
//		UniLetters[].UnicodeName = "";
//		
//		UniLetters[].Letters = new char[3];
//		UniLetters[].Letters[0] = '\u';
//		UniLetters[].Letters[1] = '\u';
//		UniLetters[].Letters[2] = '\u';
//
//		UniLetters[].IsolatedForm = '\u';
//		UniLetters[].InitialForm  = '\u';
//		UniLetters[].MedialForm   = '\u';
//		UniLetters[].FinalForm    = '\u';
//		
//		UniLetters[].Sticky_InitialForm  = '\u';
//		UniLetters[].Sticky_MedialForm   = '\u';
//		UniLetters[].Sticky_FinalForm    = '\u';
	
	
		
		
		// Special Character ""
//		specialChar[0].Name                      = "";
//		specialChar[0].Character                 = '\u';
//		specialChar[0].MetaData.ConvertToPerisan = false;
		
		#endregion Special Chracter
			
		// Arabic letter alef
		UniLetters[0].UnicodeName = "Arabic letter alef"; 
		
		UniLetters[0].Letters = new char[6];
		UniLetters[0].Letters[0] = '\u0627';
		UniLetters[0].Letters[1] = '\u0625';
		UniLetters[0].Letters[2] = '\u0623';
		UniLetters[0].Letters[3] = '\u0675'; 
		UniLetters[0].Letters[4] = '\u0673';
		UniLetters[0].Letters[5] = '\u0672';
		
		UniLetters[0].IsolatedForm = '\uFE8D'; 
		UniLetters[0].InitialForm  = '\uFE8D';
		UniLetters[0].MedialForm   = '\uFE8D';
		UniLetters[0].FinalForm    = '\uFE8D';
		
		UniLetters[0].Sticky_InitialForm  = '\uFE8D';
		UniLetters[0].Sticky_MedialForm   = '\uFE8E';
		UniLetters[0].Sticky_FinalForm    = '\uFE8E';
		
		
		
		// Arabic letter alef with madda above
		UniLetters[1].UnicodeName = "Arabic letter alef with madda above";
		
		UniLetters[1].Letters = new char[3];
		UniLetters[1].Letters[0] = '\u0622';
		UniLetters[1].Letters[1] = '\u0671';
		UniLetters[1].Letters[2] = '\uFE81';

		UniLetters[1].IsolatedForm = '\uFE81';
		UniLetters[1].InitialForm  = '\uFE81';
		UniLetters[1].MedialForm   = '\uFE81';
		UniLetters[1].FinalForm    = '\uFE81';
		
		UniLetters[1].Sticky_InitialForm  = '\uFE81';
		UniLetters[1].Sticky_MedialForm   = '\uFE82';
		UniLetters[1].Sticky_FinalForm    = '\uFE82';
		
		
		
		// Arabic letter beh
		UniLetters[2].UnicodeName = "Arabic letter beh";
		
		UniLetters[2].Letters = new char[3];
		UniLetters[2].Letters[0] = '\u0628';
		UniLetters[2].Letters[1] = '\uFE90';
		UniLetters[2].Letters[2] = '\uFE8F';
		
		UniLetters[2].IsolatedForm = '\uFE8F';
		UniLetters[2].InitialForm  =  '0';
		UniLetters[2].MedialForm   =  '0';
		UniLetters[2].FinalForm    = '\uFE90';
		
		UniLetters[2].Sticky_InitialForm  = '\uFE91';
		UniLetters[2].Sticky_MedialForm   = '\uFE92';
		UniLetters[2].Sticky_FinalForm    =  '0';		
		
		
		// Arabic letter peh final form
		UniLetters[3].UnicodeName = "Arabic letter peh final form";
		
		UniLetters[3].Letters = new char[2];
		UniLetters[3].Letters[0] = '\u067E';
		UniLetters[3].Letters[1] = '\uFB57';

		
		UniLetters[3].IsolatedForm = '\uFB56';
		UniLetters[3].InitialForm  =  '0';
		UniLetters[3].MedialForm   =  '0';
		UniLetters[3].FinalForm    = '\uFB57';
		
		UniLetters[3].Sticky_InitialForm  = '\uFB58';
		UniLetters[3].Sticky_MedialForm   = '\uFB59';
		UniLetters[3].Sticky_FinalForm    = '0';
		
		// Arabic letter teh
		UniLetters[4].UnicodeName = "Arabic letter teh isolated form";
		
		UniLetters[4].Letters = new char[4];
		UniLetters[4].Letters[0] = '\u062A';
		UniLetters[4].Letters[1] = '\u067C';
		UniLetters[4].Letters[2] = '\uFE95';
		UniLetters[4].Letters[3] = '\uFE96';
		
		
		UniLetters[4].IsolatedForm = '\uFE95';
		UniLetters[4].InitialForm  =  '0';
		UniLetters[4].MedialForm   =  '0';
		UniLetters[4].FinalForm    = '\uFE96';
		
		UniLetters[4].Sticky_InitialForm  = '\uFE97';
		UniLetters[4].Sticky_MedialForm   = '\uFE98';
		UniLetters[4].Sticky_FinalForm    = '0';
		
		// Arabic letter theh
		UniLetters[5].UnicodeName = "Arabic letter theh";
		
		UniLetters[5].Letters = new char[3];
		UniLetters[5].Letters[0] = '\u062B';
		UniLetters[5].Letters[1] = '\uFE99';
		UniLetters[5].Letters[2] = '\uFE9A';
		

		
		UniLetters[5].IsolatedForm = '\uFE99';
		UniLetters[5].InitialForm  =  '0';
		UniLetters[5].MedialForm   =  '0';
		UniLetters[5].FinalForm    = '\uFE9A';
		
		UniLetters[5].Sticky_InitialForm  = '\uFE9B';
		UniLetters[5].Sticky_MedialForm   = '\uFE9C';
		UniLetters[5].Sticky_FinalForm    =  '0';
		
		
		// Arabic letter jeem
		UniLetters[6].UnicodeName = "Arabic letter jeem";
		
		UniLetters[6].Letters = new char[3];
		UniLetters[6].Letters[0] = '\u062C';
		UniLetters[6].Letters[1] = '\uFE9D';
		UniLetters[6].Letters[2] = '\uFE9E';
		
		UniLetters[6].IsolatedForm = '\uFE9D';
		UniLetters[6].InitialForm  = '0';
		UniLetters[6].MedialForm   = '0';
		UniLetters[6].FinalForm    = '\uFE9D'; 
		
		UniLetters[6].Sticky_InitialForm  = '\uFE9F';
		UniLetters[6].Sticky_MedialForm   = '\uFEA0';
		UniLetters[6].Sticky_FinalForm    = '\uFE9E';
		
		
		
		// Arabic letter tcheh
		UniLetters[7].UnicodeName = "Arabic letter tcheh";
		
		UniLetters[7].Letters = new char[3];
		UniLetters[7].Letters[0] = '\u0686';
		UniLetters[7].Letters[1] = '\uFB7A';
		UniLetters[7].Letters[2] = '\uFB7A';

		UniLetters[7].IsolatedForm = '\uFB7A';
		UniLetters[7].InitialForm  = '0';
		UniLetters[7].MedialForm   = '0';
		UniLetters[7].FinalForm    = '0';
		
		UniLetters[7].Sticky_InitialForm  = '\uFB7C';
		UniLetters[7].Sticky_MedialForm   = '\uFB7D';
		UniLetters[7].Sticky_FinalForm    = '\uFB7B';
		
		
		
		// Arabic letter hah
		UniLetters[8].UnicodeName = "Arabic letter hah";
		
		UniLetters[8].Letters = new char[3];
		UniLetters[8].Letters[0] = '\u062D';
		UniLetters[8].Letters[1] = '\uFEA1';
		UniLetters[8].Letters[2] = '\uFEA2';

		
		UniLetters[8].IsolatedForm = '\uFEA1';
		UniLetters[8].InitialForm  = '0';
		UniLetters[8].MedialForm   = '0';
		UniLetters[8].FinalForm    = '0';
		
		UniLetters[8].Sticky_InitialForm  = '\uFEA3';
		UniLetters[8].Sticky_MedialForm   = '\uFEA4';
		UniLetters[8].Sticky_FinalForm    = '\uFEA2';
		
		
		// Arabic letter khah
		UniLetters[9].UnicodeName = "Arabic letter khah";
		
		UniLetters[9].Letters = new char[3];
		UniLetters[9].Letters[0] = '\u062E';
		UniLetters[9].Letters[1] = '\uFEA5';
		UniLetters[9].Letters[2] = '\uFEA6';

		
		UniLetters[9].IsolatedForm = '\uFEA5';
		UniLetters[9].InitialForm  = '0';
		UniLetters[9].MedialForm   = '0';
		UniLetters[9].FinalForm    = '0';
		
		UniLetters[9].Sticky_InitialForm  = '\uFEA7';
		UniLetters[9].Sticky_MedialForm   = '\uFEA8';
		UniLetters[9].Sticky_FinalForm    = '\uFEA6';
		
		
		
		//Arabic letter dal
		UniLetters[10].UnicodeName = "Arabic letter dal";
		
		UniLetters[10].Letters = new char[3];
		UniLetters[10].Letters[0] = '\u062F';
		UniLetters[10].Letters[1] = '\uFEA9';
		UniLetters[10].Letters[2] = '\uFEAA';

		
		UniLetters[10].IsolatedForm = '\uFEA9';
		UniLetters[10].InitialForm  = '\uFEA9';
		UniLetters[10].MedialForm   = '\uFEAA';
		UniLetters[10].FinalForm    = '\uFEAA';
		
		UniLetters[10].Sticky_InitialForm  = '0';
		UniLetters[10].Sticky_MedialForm   = '0';
		UniLetters[10].Sticky_FinalForm    = '0';
		
		
		
		//Arabic letter thal
		UniLetters[11].UnicodeName = "Arabic letter thal";
		
		UniLetters[11].Letters = new char[3];
		UniLetters[11].Letters[0] = '\u0630';
		UniLetters[11].Letters[1] = '\uFEAB';
		UniLetters[11].Letters[2] = '\uFEAC';

		UniLetters[11].IsolatedForm = '\uFEAB';
		UniLetters[11].InitialForm  = '\uFEAB';
		UniLetters[11].MedialForm   = '\uFEAC';
		UniLetters[11].FinalForm    = '\uFEAC';
		
		UniLetters[11].Sticky_InitialForm  = '0';
		UniLetters[11].Sticky_MedialForm   = '0';
		UniLetters[11].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter reh
		UniLetters[12].UnicodeName = "Arabic letter reh";
		
		UniLetters[12].Letters = new char[3];
		UniLetters[12].Letters[0] = '\u0631';
		UniLetters[12].Letters[1] = '\uFEAD';
		UniLetters[12].Letters[2] = '\uFEAE';

		
		UniLetters[12].IsolatedForm = '\uFEAD';
		UniLetters[12].InitialForm  = '\uFEAD';
		UniLetters[12].MedialForm   = '\uFEAE';
		UniLetters[12].FinalForm    = '\uFEAE';
		
		UniLetters[12].Sticky_InitialForm  = '0';
		UniLetters[12].Sticky_MedialForm   = '0';
		UniLetters[12].Sticky_FinalForm    = '0';
		
		
		
		//Arabic letter zain
		UniLetters[13].UnicodeName = "Arabic letter zain";
		
		UniLetters[13].Letters = new char[3];
		UniLetters[13].Letters[0] = '\u0632';
		UniLetters[13].Letters[1] = '\uFEAF';
		UniLetters[13].Letters[2] = '\uFEB0';
		
		UniLetters[13].IsolatedForm = '\uFEAF';
		UniLetters[13].InitialForm  = '\uFEAF';
		UniLetters[13].MedialForm   = '\uFEB0';
		UniLetters[13].FinalForm    = '\uFEB0';
		
		UniLetters[13].Sticky_InitialForm  = '0';
		UniLetters[13].Sticky_MedialForm   = '0';
		UniLetters[13].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter jeh
		UniLetters[14].UnicodeName = "Arabic letter jeh";
		
		UniLetters[14].Letters = new char[3];
		UniLetters[14].Letters[0] = '\u0698';
		UniLetters[14].Letters[1] = '\uFB8A';
		UniLetters[14].Letters[2] = '\uFB8B';
		
		UniLetters[14].IsolatedForm = '\uFB8A';
		UniLetters[14].InitialForm  = '\uFB8A';
		UniLetters[14].MedialForm   = '\uFB8B';
		UniLetters[14].FinalForm    = '\uFB8B';
		
		UniLetters[14].Sticky_InitialForm  = '0';
		UniLetters[14].Sticky_MedialForm   = '0';
		UniLetters[14].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter seen
		UniLetters[15].UnicodeName = "Arabic letter seen";
		
		UniLetters[15].Letters = new char[1];
		UniLetters[15].Letters[0] = '\u0633';

		UniLetters[15].IsolatedForm = '\uFEB1';
		UniLetters[15].InitialForm  = '0';
		UniLetters[15].MedialForm   = '0';
		UniLetters[15].FinalForm    = '\uFEB2';
		
		UniLetters[15].Sticky_InitialForm  = '\uFEB3';
		UniLetters[15].Sticky_MedialForm   = '\uFEB4';
		UniLetters[15].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter sheen
		UniLetters[16].UnicodeName = "Arabic letter shee";
		
		UniLetters[16].Letters = new char[5];
		UniLetters[16].Letters[0] = '\u0634';
		UniLetters[16].Letters[1] = '\uFEB5';
		UniLetters[16].Letters[2] = '\uFEB7';
		UniLetters[16].Letters[3] = '\uFEB8';
		UniLetters[16].Letters[4] = '\uFEB5';
		
		UniLetters[16].IsolatedForm = '\uFEB5';
		UniLetters[16].InitialForm  = '0';
		UniLetters[16].MedialForm   = '0';
		UniLetters[16].FinalForm    = '\uFEB6';
		
		UniLetters[16].Sticky_InitialForm  = '\uFEB7';
		UniLetters[16].Sticky_MedialForm   = '\uFEB8';
		UniLetters[16].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter sad
		UniLetters[17].UnicodeName = "Arabic letter sad";
		
		UniLetters[17].Letters = new char[3];
		UniLetters[17].Letters[0] = '\u0635';
		UniLetters[17].Letters[1] = '\uFEB9';
		UniLetters[17].Letters[2] = '\uFEBA';
		
		UniLetters[17].IsolatedForm = '\uFEB9';
		UniLetters[17].InitialForm  = '0';
		UniLetters[17].MedialForm   = '0';
		UniLetters[17].FinalForm    = '\uFEBA';
		
		UniLetters[17].Sticky_InitialForm  = '\uFEBB';
		UniLetters[17].Sticky_MedialForm   = '\uFEBC';
		UniLetters[17].Sticky_FinalForm    = '0';
		
		
		
		//Arabic letter dad
		UniLetters[18].UnicodeName = "Arabic letter dad";
		
		UniLetters[18].Letters = new char[3];
		UniLetters[18].Letters[0] = '\u0636';
		UniLetters[18].Letters[1] = '\uFEBD';
		UniLetters[18].Letters[2] = '\uFEBE';

		UniLetters[18].IsolatedForm = '\uFEBD';
		UniLetters[18].InitialForm  = '0';
		UniLetters[18].MedialForm   = '0';
		UniLetters[18].FinalForm    = '\uFEBE';
		
		UniLetters[18].Sticky_InitialForm  = '\uFEBF';
		UniLetters[18].Sticky_MedialForm   = '\uFEC0';
		UniLetters[18].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter tah
		UniLetters[19].UnicodeName = "Arabic letter tah";
		
		UniLetters[19].Letters = new char[5];
		UniLetters[19].Letters[0] = '\u0637';
		UniLetters[19].Letters[1] = '\uFEC1';
		UniLetters[19].Letters[2] = '\uFEC2';
		UniLetters[19].Letters[3] = '\uFEC3';
		UniLetters[19].Letters[4] = '\uFEC4';

		UniLetters[19].IsolatedForm = '\uFEC1';
		UniLetters[19].InitialForm  = '0';
		UniLetters[19].MedialForm   = '0';
		UniLetters[19].FinalForm    = '\uFEC2';
		
		UniLetters[19].Sticky_InitialForm  = '\uFEC3';
		UniLetters[19].Sticky_MedialForm   = '\uFEC4';
		UniLetters[19].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter zah
		UniLetters[20].UnicodeName = "Arabic letter zah";
		
		UniLetters[20].Letters = new char[5];
		UniLetters[20].Letters[0] = '\u0638';
		UniLetters[20].Letters[1] = '\uFEC5';
		UniLetters[20].Letters[2] = '\uFEC6';
		UniLetters[20].Letters[3] = '\uFEC7';
		UniLetters[20].Letters[4] = '\uFEC8';

		UniLetters[20].IsolatedForm = '\uFEC5';
		UniLetters[20].InitialForm  = '0';
		UniLetters[20].MedialForm   = '0';
		UniLetters[20].FinalForm    = '\uFEC6';
		
		UniLetters[20].Sticky_InitialForm  = '\uFEC7';
		UniLetters[20].Sticky_MedialForm   = '\uFEC8';
		UniLetters[20].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter ain
		UniLetters[21].UnicodeName = "Arabic letter ain";
		
		UniLetters[21].Letters = new char[2];
		UniLetters[21].Letters[0] = '\u0639';
		UniLetters[21].Letters[1] = '\uFEC9';
		

		UniLetters[21].IsolatedForm = '\uFEC9';
		UniLetters[21].InitialForm  = '0';
		UniLetters[21].MedialForm   = '0';
		UniLetters[21].FinalForm    = '0';
		
		UniLetters[21].Sticky_InitialForm  = '\uFECB';
		UniLetters[21].Sticky_MedialForm   = '\uFECC';
		UniLetters[21].Sticky_FinalForm    = '\uFECA';
		UniLetters[21].Sticky_Both         = '\uFECC';
		
		
		// Arabic letter ghain
		UniLetters[22].UnicodeName = "Arabic letter ghain";
		
		UniLetters[22].Letters = new char[2];
		UniLetters[22].Letters[0] = '\u063A';
		UniLetters[22].Letters[1] = '\uFECD';
		

		UniLetters[22].IsolatedForm = '\uFECD';
		UniLetters[22].InitialForm  = '0';
		UniLetters[22].MedialForm   = '0';
		UniLetters[22].FinalForm    = '0';
		
		UniLetters[22].Sticky_InitialForm  = '\uFECF';
		UniLetters[22].Sticky_MedialForm   = '\uFED0';
		UniLetters[22].Sticky_FinalForm    = '\uFECE';
		UniLetters[22].Sticky_Both         = '\uFED0';
		
		
		// Arabic letter feh
		UniLetters[23].UnicodeName = "Arabic letter feh";
		
		UniLetters[23].Letters = new char[3];
		UniLetters[23].Letters[0] = '\u0641';
		UniLetters[23].Letters[1] = '\uFED1';
		UniLetters[23].Letters[2] = '\uFED2';

		UniLetters[23].IsolatedForm = '\uFED1';
		UniLetters[23].InitialForm  = '0';
		UniLetters[23].MedialForm   = '0';
		UniLetters[23].FinalForm    = '\uFED2';
		
		UniLetters[23].Sticky_InitialForm  = '\uFED3';
		UniLetters[23].Sticky_MedialForm   = '\uFED4';
		UniLetters[23].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter qaf
		UniLetters[24].UnicodeName = "Arabic letter qaf";
		
		UniLetters[24].Letters = new char[3];
		UniLetters[24].Letters[0] = '\u0642';
		UniLetters[24].Letters[1] = '\uFED5';
		UniLetters[24].Letters[2] = '\uFED6';

		UniLetters[24].IsolatedForm = '\uFED5';
		UniLetters[24].InitialForm  = '0';
		UniLetters[24].MedialForm   = '0';
		UniLetters[24].FinalForm    = '\uFED6';
		
		UniLetters[24].Sticky_InitialForm  = '\uFED7';
		UniLetters[24].Sticky_MedialForm   = '\uFED8';
		UniLetters[24].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter keheh
		UniLetters[25].UnicodeName = "Arabic letter keheh";
		
		UniLetters[25].Letters = new char[6];
		UniLetters[25].Letters[0] = '\u06A9';
		UniLetters[25].Letters[1] = '\u0643';
		UniLetters[25].Letters[2] = '\u06AB';
		UniLetters[25].Letters[3] = '\uFEDA';
		UniLetters[25].Letters[4] = '\uFED9';
		UniLetters[25].Letters[5] = '\uFB8E';
		
		UniLetters[25].IsolatedForm = '\uFB8E';
		UniLetters[25].InitialForm  = '0';
		UniLetters[25].MedialForm   = '0';
		UniLetters[25].FinalForm    = '0';
		
		UniLetters[25].Sticky_InitialForm  = '\uFB90';
		UniLetters[25].Sticky_MedialForm   = '\uFB91';
		UniLetters[25].Sticky_FinalForm    = '\uFB8F';
		
		
		
		// Arabic letter gaf
		UniLetters[26].UnicodeName = "Arabic letter gaf";
		
		UniLetters[26].Letters = new char[2];
		UniLetters[26].Letters[0] = '\u06AF';
		UniLetters[26].Letters[1] = '\uFB92';

		UniLetters[26].IsolatedForm = '\uFB92';
		UniLetters[26].InitialForm  = '0';
		UniLetters[26].MedialForm   = '0';
		UniLetters[26].FinalForm    = '0';
		
		UniLetters[26].Sticky_InitialForm  = '\uFB94';
		UniLetters[26].Sticky_MedialForm   = '\uFB95';
		UniLetters[26].Sticky_FinalForm    = '\uFB93';
		
		
		
		// Arabic letter lam
		UniLetters[27].UnicodeName = "Arabic letter lam";
		
		UniLetters[27].Letters = new char[3];
		UniLetters[27].Letters[0] = '\u0644';
		UniLetters[27].Letters[1] = '\uFEDD';
		UniLetters[27].Letters[2] = '\uFEDE';

		UniLetters[27].IsolatedForm = '\uFEDD';
		UniLetters[27].InitialForm  = '0';
		UniLetters[27].MedialForm   = '0';
		UniLetters[27].FinalForm    = '\uFEDE';
		
		UniLetters[27].Sticky_InitialForm  = '\uFEDF';
		UniLetters[27].Sticky_MedialForm   = '\uFEE0';
		UniLetters[27].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter meem
		UniLetters[28].UnicodeName = "Arabic letter meem";
		
		UniLetters[28].Letters = new char[3];
		UniLetters[28].Letters[0] = '\u0645';
		UniLetters[28].Letters[1] = '\uFEE1';
		UniLetters[28].Letters[2] = '\uFEE2';

		UniLetters[28].IsolatedForm = '\uFEE1';
		UniLetters[28].InitialForm  = '0';
		UniLetters[28].MedialForm   = '0';
		UniLetters[28].FinalForm    = '\uFEE2';
		
		UniLetters[28].Sticky_InitialForm  = '\uFEE3';
		UniLetters[28].Sticky_MedialForm   = '\uFEE4';
		UniLetters[28].Sticky_FinalForm    = '0';
		
		
		// Arabic letter noon
		UniLetters[29].UnicodeName = "Arabic letter noon";
		
		UniLetters[29].Letters = new char[3];
		UniLetters[29].Letters[0] = '\u0646';
		UniLetters[29].Letters[1] = '\uFEE5';
		UniLetters[29].Letters[2] = '\uFEE6';

		UniLetters[29].IsolatedForm = '\uFEE5';
		UniLetters[29].InitialForm  = '0';
		UniLetters[29].MedialForm   = '0';
		UniLetters[29].FinalForm    = '\uFEE6';
		
		UniLetters[29].Sticky_InitialForm  = '\uFEE7';
		UniLetters[29].Sticky_MedialForm   = '\uFEE8';
		UniLetters[29].Sticky_FinalForm    = '0';
	
		
		// Arabic letter waw
		UniLetters[30].UnicodeName = "Arabic letter waw";
		
		UniLetters[30].Letters = new char[3];
		UniLetters[30].Letters[0] = '\u0648';
		UniLetters[30].Letters[1] = '\uFEED';
		UniLetters[30].Letters[2] = '\uFEEE';

		UniLetters[30].IsolatedForm = '\uFEED';
		UniLetters[30].InitialForm  = '\uFEED';
		UniLetters[30].MedialForm   = '\uFEEE';
		UniLetters[30].FinalForm    = '\uFEEE';
		
		UniLetters[30].Sticky_InitialForm  = '0';
		UniLetters[30].Sticky_MedialForm   = '0';
		UniLetters[30].Sticky_FinalForm    = '0';
		
		
		
		// Arabic letter heh
		UniLetters[31].UnicodeName = "Arabic letter heh";
		
		UniLetters[31].Letters = new char[7];
		UniLetters[31].Letters[0] = '\u0647';
		UniLetters[31].Letters[1] = '\uFEE9';
		UniLetters[31].Letters[2] = '\u06C1';
		UniLetters[31].Letters[3] = '\u06C0';
		UniLetters[31].Letters[4] = '\u06C2';
		UniLetters[31].Letters[5] = '\u06C3';
		UniLetters[31].Letters[6] = '\u06C2';
		
		UniLetters[31].IsolatedForm = '\uFEE9';
		UniLetters[31].InitialForm  = '0';
		UniLetters[31].MedialForm   = '0';
		UniLetters[31].FinalForm    = '0';
		
		UniLetters[31].Sticky_InitialForm  = '\uFEEB';
		UniLetters[31].Sticky_MedialForm   = '\uFEEC';
		UniLetters[31].Sticky_FinalForm    = '\uFEEA';
		UniLetters[31].Sticky_Both         = '\uFEEC';
		
		
		
		// Arabic letter farsi yeh
		UniLetters[32].UnicodeName = "Arabic letter farsi yeh";
		
		UniLetters[32].Letters = new char[9];
		UniLetters[32].Letters[0] = '\u06CC';
		UniLetters[32].Letters[1] = '\u0649';
		UniLetters[32].Letters[2] = '\u064A';
		UniLetters[32].Letters[3] = '\uFBFC';
		UniLetters[32].Letters[4] = '\uFEF0';
		UniLetters[32].Letters[5] = '\uFEF2';
		UniLetters[32].Letters[6] = '\uFEF1';
		UniLetters[32].Letters[7] = '\uFEF0';
		UniLetters[32].Letters[8] = '\uFEEF';
		
		UniLetters[32].IsolatedForm = '\uFBFC';
		UniLetters[32].InitialForm  = '0';
		UniLetters[32].MedialForm   = '0';
		UniLetters[32].FinalForm    = '0';
		
		UniLetters[32].Sticky_InitialForm  = '\uFBFE';
		UniLetters[32].Sticky_MedialForm   = '\uFBFF';
		UniLetters[32].Sticky_FinalForm    = '\uFBFD';
		
		
		
		
		//
//		UniLetters[].UnicodeName = "";
//		
//		UniLetters[].Letters = new char[3];
//		UniLetters[].Letters[0] = '\u';
//		UniLetters[].Letters[1] = '\u';
//		UniLetters[].Letters[2] = '\u';
//
//		UniLetters[].IsolatedForm = '\u';
//		UniLetters[].InitialForm  = '\u';
//		UniLetters[].MedialForm   = '\u';
//		UniLetters[].FinalForm    = '\u';
//		
//		UniLetters[].Sticky_InitialForm  = '\u';
//		UniLetters[].Sticky_MedialForm   = '\u';
//		UniLetters[].Sticky_FinalForm    = '\u';
		
		
		
		
		//
//		UniLetters[].UnicodeName = "";
//		
//		UniLetters[].Letters = new char[3];
//		UniLetters[].Letters[0] = '\u';
//		UniLetters[].Letters[1] = '\u';
//		UniLetters[].Letters[2] = '\u';
//
//		UniLetters[].IsolatedForm = '\u';
//		UniLetters[].InitialForm  = '\u';
//		UniLetters[].MedialForm   = '\u';
//		UniLetters[].FinalForm    = '\u';
//		
//		UniLetters[].Sticky_InitialForm  = '\u';
//		UniLetters[].Sticky_MedialForm   = '\u';
//		UniLetters[].Sticky_FinalForm    = '\u';
		
    }
    void Start()
    {
		newstyle.font=this.GetComponent<GUIText>().font;
		newstyle.fontSize=30;	
    }

    void Update()
    {
	}	 
	
	
	private void addStrToCharArr(ref char[] charArr,string str,int StartCharIndex, int EndCharIndex)
	{
		for(int k = 0; k <= (EndCharIndex - StartCharIndex);k++ )
		{
			charArr[k] = str[StartCharIndex + k];
		}
	}
	
	private bool compareCharWithSpecialChar(char chr, out int index)
	{
		for (int i = SPECIAL_CHAR_START_INDEX; i <= SPECIAL_CHAR_END_INDEX; i++) 
		{
			for (int j = 0; j < UniLetters[i].Letters.Length; j++) 
			{
				
				if(chr == UniLetters[i].Letters[j])
				{
					index = i;
					return true;
				}
			}
		}
		index = -1;
		return false;
	}
	
	private bool isPerisanLetter(char chr)
	{
		
		bool IsPersianWord = false;
		bool exit = false;
		
		for (int m = 0; m < PERSIAN_LETTERS_LENGTH; m++) //find out this letter is perisan or not
		{
		 
			for (int n = 0; n < UniLetters[m].Letters.Length; n++) 
			{
				if (chr == UniLetters[m].Letters[n])// this is perisan letter and need to be converted
				{
					IsPersianWord = true;
					exit = true;
					break;
				}

			}
			if (exit)
			{
				exit = false;
				break;
			}
		}		
		return IsPersianWord;
	}
	
	void StringToWords(string str, ref List<WordWithMetaData> WordsArray,int nextStartPoint)
	{

		char[] charArr 			= new char[100];
	 
		int StartCharIndex 		= 0;
		int EndCharIndex  		= 0;
		int SpecialCharIndex 	= 0;
		int strLength 			= str.Length;
		bool StartCharIsPersian = false;
		bool exit 				= false;
		
		for (int i = nextStartPoint; i < strLength;  i++)
		{
			
			if(compareCharWithSpecialChar(str[i],out SpecialCharIndex))//this character is special charachter
			{
				WordWithMetaData temp1 = new WordWithMetaData();
			   
				temp1.Word = new char[1];
				temp1.Word[0] = UniLetters[SpecialCharIndex].IsolatedForm;
				temp1.MetaData = UniLetters[SpecialCharIndex].MetaData;
				temp1.MetaData.WordType = _WordType.Special;
				WordsArray.Add(temp1);
				
				nextStartPoint = i+1;
				
				StringToWords(str,ref WordsArray,nextStartPoint);
				exit = true;
				break;
			}	
			else // thsi character is not special character	
			{		

				StartCharIndex 	   = i;//save start index
				StartCharIsPersian = isPerisanLetter(str[StartCharIndex]);
				
				if(StartCharIndex == strLength - 1)
					StartCharIndex--;
				
				for(int j = StartCharIndex + 1; j < strLength;j++)// looking for special character to find end of word
				{
					if(StartCharIsPersian)//start letter is perisan and for finding end index, we need to check special character and non persian letter
					{
						if(compareCharWithSpecialChar(str[j],out SpecialCharIndex) || isPerisanLetter(str[j]) == false)//found end index of word
						{
							
							EndCharIndex  = j - 1;//save end index
							nextStartPoint = j;//save next index after last word
							charArr = new char[ (EndCharIndex - StartCharIndex) + 1 ]; // redime character array
							addStrToCharArr(ref charArr,str,StartCharIndex,EndCharIndex);
							WordWithMetaData temp2 = new WordWithMetaData();
							temp2.Word = charArr;
							temp2.MetaData.ConvertToPerisan = true;// this is a persian word and must converted to persian
							temp2.MetaData.WordType = _WordType.Persian;
							WordsArray.Add(temp2);
							charArr = new char[1];
							StringToWords(str, ref WordsArray,nextStartPoint);
							exit = true;
							break;
								
						}
					}
					else //start letter is not perisan and for finding end index, we need to check special character and persian letter
					{
						if(compareCharWithSpecialChar(str[j],out SpecialCharIndex) || isPerisanLetter(str[j]))//found end index of word 
						{
							
							EndCharIndex  = j - 1;//save end index
							nextStartPoint = j;//save next index after last word
							charArr = new char[ (EndCharIndex - StartCharIndex) + 1 ]; // redime character array
							addStrToCharArr(ref charArr,str,StartCharIndex,EndCharIndex);
							WordWithMetaData temp3 = new WordWithMetaData();
							temp3.Word = charArr;
							temp3.MetaData.ConvertToPerisan = false;// this is a foreign word and convert is not necessary
							temp3.MetaData.WordType = _WordType.Foreign;
							WordsArray.Add(temp3);
							charArr = new char[1];
							StringToWords(str, ref WordsArray,nextStartPoint);
							exit = true;
							break;
								
						}
					}
					
				    if(j == strLength - 1)
					{
						EndCharIndex   = j;//save end index
						charArr = new char[ (EndCharIndex - StartCharIndex) + 1 ]; // redime character array
						addStrToCharArr(ref charArr,str,StartCharIndex,EndCharIndex);
						WordWithMetaData temp4 = new WordWithMetaData();
						temp4.Word = charArr;
						temp4.MetaData.ConvertToPerisan = StartCharIsPersian;// this is a raw word and must converted to persian
						if(StartCharIsPersian)
							temp4.MetaData.WordType = _WordType.Persian;
						else
							temp4.MetaData.WordType = _WordType.Foreign;
									
						WordsArray.Add(temp4);
						charArr = new char[1];// clean char array up
						exit = true;
						break;
					}
				}

			}
			if (exit)
			{
				exit = false;
				break;
			}
	   }
		
	}
	
	private string ToPersianWord(string str)
	{
		char[] chrArr = str.ToCharArray();
		int chrArrLen = chrArr.Length;
		int preLetter = 0;
		int[] iRelativej = new int[chrArrLen];
		bool exit = false;
		
		for (int i = 0; i < chrArrLen; i++)
		{
		
			for (int j = 0; j < UNICODE_LETTERS_LENGTH; j++)
			{
			
				for(int k = 0; k < UniLetters[j].Letters.Length; k++) 
				{
					if(chrArr[i] == UniLetters[j].Letters[k])
					{

						if(i == 0) // this letter is first letter
						{
							if(i == chrArrLen - 1)//this word is just have one letter
							{
								chrArr[i] = UniLetters[j].IsolatedForm;
								exit = true;
								break;
							}
							else
							{
								if(UniLetters[j].InitialForm == '0') //this letter do not have non sticky form
									chrArr[i] = UniLetters[j].Sticky_InitialForm;
								else
									chrArr[i] = UniLetters[j].InitialForm;
							}
							iRelativej[i] = j;
							exit = true;
							break;
						}
						else
						if (i == chrArrLen - 1) // this letter is final letter
						{
						    preLetter = i - 1; 
							if ( preLetter == 0) //previus letter is first letter
							{
								if(UniLetters[iRelativej[preLetter]].InitialForm != '0') //previus letter is not sticky
								{
									if (UniLetters[j].FinalForm == '0') //this letter do not have non sticky form
										chrArr[i] = UniLetters[j].IsolatedForm;
									else
										chrArr[i] = UniLetters[j].IsolatedForm;
								}
								else // previus letter is sticky
								{
									if(UniLetters[j].Sticky_FinalForm == '0')// this letter do not have sticky form
										chrArr[i] = UniLetters[j].IsolatedForm;
									else
										chrArr[i] = UniLetters[j].Sticky_FinalForm;
									
								}
								
								iRelativej[i] = j;
								exit = true;
								break;
							}
							else //previus letter is middle letter
							{
								if(UniLetters[iRelativej[preLetter]].MedialForm != '0') // previus letter is not sticky
								{
									if (UniLetters[j].FinalForm == '0') //this letter do not have non sticky form
										chrArr[i] = UniLetters[j].IsolatedForm;
									else
										chrArr[i] = UniLetters[j].IsolatedForm;
								}
								else //previus letter is sticky
								{
									if(UniLetters[j].Sticky_FinalForm == '0') //this letter do not have sticky form
										chrArr[i] = UniLetters[j].FinalForm;
									else
										chrArr[i] = UniLetters[j].Sticky_FinalForm;
								}
								
								iRelativej[i] = j;
								exit = true;
								break;
							}
							
						}
						else // this letter is medial letter
						{
							
						    preLetter = i - 1; 
							if ( preLetter == 0) //previus letter is first letter
							{
								if(UniLetters[iRelativej[preLetter]].InitialForm != '0') //previus letter is not sticky
								{
									if (UniLetters[j].MedialForm == '0') //this letter do not have non sticky form
										chrArr[i] = UniLetters[j].Sticky_InitialForm;//we sure this form do not have backward sticky
									else
										chrArr[i] = UniLetters[j].IsolatedForm;
								}
								else // previus letter is sticky
								{
									if(UniLetters[j].Sticky_Both != '\0')//this letter have both sicky form 
									{
										chrArr[i] = UniLetters[j].Sticky_Both;
									}
									else
									{
									if(UniLetters[j].Sticky_MedialForm == '0')// this letter do not have sticky form
										chrArr[i] = UniLetters[j].MedialForm;
									else
										chrArr[i] = UniLetters[j].Sticky_MedialForm;
									}
									
								}
							
								iRelativej[i] = j;
								exit = true;
								break;
							}
							else //previus letter is middle letter
							{
								if(UniLetters[iRelativej[preLetter]].MedialForm != '0') // previus letter is not sticky
								{
									if (UniLetters[j].MedialForm == '0') //this letter do not have non sticky form
										chrArr[i] = UniLetters[j].Sticky_InitialForm;//we sure this form do not have backward sticky
									else
										chrArr[i] = UniLetters[j].IsolatedForm;
								}
								else //previus letter is sticky
								{
									if(UniLetters[j].Sticky_Both != '\0')// this letter have both sticky form
									{
										chrArr[i] = UniLetters[j].Sticky_Both;
									}
									else
									{
									if(UniLetters[j].Sticky_MedialForm == '0') //this letter do not have sticky form
										chrArr[i] = UniLetters[j].MedialForm;
									else
										chrArr[i] = UniLetters[j].Sticky_MedialForm;
									}
								}
								
								iRelativej[i] = j;
								exit = true;
								break;
							}
							
						}
					}
				}	 
				if (exit)
				{
					exit = false; 
					break;	
				}
					
			}	 
		}
		Array.Reverse(chrArr);     
		return new string(chrArr);  
	}	
	
	string ToPersianString(String str)
	{
		List<WordWithMetaData> Words 		= new List<WordWithMetaData>();//list of all words include special, persian and foreign.
		List<WordWithMetaData> ForeignWords = new List<WordWithMetaData>();//list of foreign words.
		List<int> PosInWords			    = new List<int>();//contain position of each foreign word in words list.
		StringToWords(str,ref Words,0);
	    string CorrecteString = "";

		for (int k = 0; k < Words.Count; k++) 
		{
			if(Words[k].MetaData.WordType == _WordType.Foreign)
			{
				ForeignWords.Add(Words[k]);
				PosInWords.Add(k);
			}
			
		}
		ForeignWords.Reverse(); //reverse foreign words to match right to left replacement
		
		for (int l = 0; l < ForeignWords.Count; l++) {
			
			Words[ PosInWords[l] ] = ForeignWords[l]; 
		}
		
		for (int i = Words.Count - 1; i >= 0;i--)
		{
			if(Words[i].MetaData.ConvertToPerisan == true)
			{
				string temp = ToPersianWord(new string (Words[i].Word));
				CorrecteString += temp;
			}
			else
			{
				
				CorrecteString += new string (Words[i].Word);
			}
		}		
		return CorrecteString;
	}
	
	GUIStyle newstyle = new GUIStyle();
	
	void OnGUI()
	{	

	 a = GUI.TextArea(new Rect(10,10,Screen.width,80),a,newstyle) ;
	
	if (GUI.Button(new Rect(300,90,100,50),"To Persian"))	
		{
			//aidin = this.GetComponent<GUIText>().text;
			string me1 = ToPersianString(a);
			
		   
			this.GetComponent<GUIText>().text = me1;

		}
	}
    #endregion
	
	void OnMouseOver()
	{
		print("this is it");
	}
}

