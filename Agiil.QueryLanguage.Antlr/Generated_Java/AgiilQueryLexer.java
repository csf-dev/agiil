// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/AgiilQuery.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class AgiilQueryLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		BOM=1, OPENPAREN=2, CLOSEPAREN=3, EQUALS=4, NOTEQUALS=5, TILDE=6, COMMA=7, 
		DOUBLEQUOTE=8, GREATERTHAN=9, LESSTHAN=10, GREATERTHANOREQUAL=11, LESSTHANOREQUAL=12, 
		WHITESPACE=13, NOT=14, AND=15, OR=16, ORDERBY=17, DESCENDING=18, ASCENDING=19, 
		NAME=20, WORD=21, QUOTEDVALUE=22, ANY=23;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"A", "B", "C", "D", "E", "G", "H", "I", "K", "L", "N", "O", "R", "S", 
		"T", "Y", "UPPERCASE", "LOWERCASE", "DIGIT", "BOM", "OPENPAREN", "CLOSEPAREN", 
		"EQUALS", "NOTEQUALS", "TILDE", "COMMA", "DOUBLEQUOTE", "GREATERTHAN", 
		"LESSTHAN", "GREATERTHANOREQUAL", "LESSTHANOREQUAL", "WHITESPACE", "NOT", 
		"AND", "OR", "ORDERBY", "DESCENDING", "ASCENDING", "NAME", "WORD", "QUOTEDVALUE", 
		"ANY"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'\uFEFF'", "'('", "')'", "'='", "'!='", "'~'", "','", "'\"'", "'>'", 
		"'<'", "'>='", "'<='"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "BOM", "OPENPAREN", "CLOSEPAREN", "EQUALS", "NOTEQUALS", "TILDE", 
		"COMMA", "DOUBLEQUOTE", "GREATERTHAN", "LESSTHAN", "GREATERTHANOREQUAL", 
		"LESSTHANOREQUAL", "WHITESPACE", "NOT", "AND", "OR", "ORDERBY", "DESCENDING", 
		"ASCENDING", "NAME", "WORD", "QUOTEDVALUE", "ANY"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public AgiilQueryLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "AgiilQuery.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\31\u00e9\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t"+
		" \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t"+
		"+\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t\3\t\3\n"+
		"\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3\21\3\21"+
		"\3\22\3\22\3\23\3\23\3\24\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30"+
		"\3\31\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3\37"+
		"\3\37\3\37\3 \3 \3 \3!\3!\3!\3!\5!\u009d\n!\3!\3!\3\"\3\"\3\"\3\"\3#\3"+
		"#\3#\3#\3$\3$\3$\3%\3%\3%\3%\3%\3%\3%\3%\3%\3&\3&\3&\3&\3&\3&\3&\3&\3"+
		"&\3&\3&\5&\u00c0\n&\3\'\3\'\3\'\3\'\3\'\3\'\3\'\3\'\3\'\3\'\5\'\u00cc"+
		"\n\'\3(\3(\3(\5(\u00d1\n(\3(\3(\3(\3(\6(\u00d7\n(\r(\16(\u00d8\3)\3)\3"+
		"*\3*\3*\3*\7*\u00e1\n*\f*\16*\u00e4\13*\3*\3*\3+\3+\2\2,\3\2\5\2\7\2\t"+
		"\2\13\2\r\2\17\2\21\2\23\2\25\2\27\2\31\2\33\2\35\2\37\2!\2#\2%\2\'\2"+
		")\3+\4-\5/\6\61\7\63\b\65\t\67\n9\13;\f=\r?\16A\17C\20E\21G\22I\23K\24"+
		"M\25O\26Q\27S\30U\31\3\2\30\4\2CCcc\4\2DDdd\4\2EEee\4\2FFff\4\2GGgg\4"+
		"\2IIii\4\2JJjj\4\2KKkk\4\2MMmm\4\2NNnn\4\2PPpp\4\2QQqq\4\2TTtt\4\2UUu"+
		"u\4\2VVvv\4\2[[{{\3\2C\\\3\2c|\3\2\62;\4\2\13\13\"\"\t\2\13\f\17\17\""+
		"#*+..??\u0080\u0080\4\2$$^^\2\u00e1\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2"+
		"/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2"+
		"\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2"+
		"G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3"+
		"\2\2\2\2U\3\2\2\2\3W\3\2\2\2\5Y\3\2\2\2\7[\3\2\2\2\t]\3\2\2\2\13_\3\2"+
		"\2\2\ra\3\2\2\2\17c\3\2\2\2\21e\3\2\2\2\23g\3\2\2\2\25i\3\2\2\2\27k\3"+
		"\2\2\2\31m\3\2\2\2\33o\3\2\2\2\35q\3\2\2\2\37s\3\2\2\2!u\3\2\2\2#w\3\2"+
		"\2\2%y\3\2\2\2\'{\3\2\2\2)}\3\2\2\2+\177\3\2\2\2-\u0081\3\2\2\2/\u0083"+
		"\3\2\2\2\61\u0085\3\2\2\2\63\u0088\3\2\2\2\65\u008a\3\2\2\2\67\u008c\3"+
		"\2\2\29\u008e\3\2\2\2;\u0090\3\2\2\2=\u0092\3\2\2\2?\u0095\3\2\2\2A\u009c"+
		"\3\2\2\2C\u00a0\3\2\2\2E\u00a4\3\2\2\2G\u00a8\3\2\2\2I\u00ab\3\2\2\2K"+
		"\u00b4\3\2\2\2M\u00c1\3\2\2\2O\u00d0\3\2\2\2Q\u00da\3\2\2\2S\u00dc\3\2"+
		"\2\2U\u00e7\3\2\2\2WX\t\2\2\2X\4\3\2\2\2YZ\t\3\2\2Z\6\3\2\2\2[\\\t\4\2"+
		"\2\\\b\3\2\2\2]^\t\5\2\2^\n\3\2\2\2_`\t\6\2\2`\f\3\2\2\2ab\t\7\2\2b\16"+
		"\3\2\2\2cd\t\b\2\2d\20\3\2\2\2ef\t\t\2\2f\22\3\2\2\2gh\t\n\2\2h\24\3\2"+
		"\2\2ij\t\13\2\2j\26\3\2\2\2kl\t\f\2\2l\30\3\2\2\2mn\t\r\2\2n\32\3\2\2"+
		"\2op\t\16\2\2p\34\3\2\2\2qr\t\17\2\2r\36\3\2\2\2st\t\20\2\2t \3\2\2\2"+
		"uv\t\21\2\2v\"\3\2\2\2wx\t\22\2\2x$\3\2\2\2yz\t\23\2\2z&\3\2\2\2{|\t\24"+
		"\2\2|(\3\2\2\2}~\7\uff01\2\2~*\3\2\2\2\177\u0080\7*\2\2\u0080,\3\2\2\2"+
		"\u0081\u0082\7+\2\2\u0082.\3\2\2\2\u0083\u0084\7?\2\2\u0084\60\3\2\2\2"+
		"\u0085\u0086\7#\2\2\u0086\u0087\7?\2\2\u0087\62\3\2\2\2\u0088\u0089\7"+
		"\u0080\2\2\u0089\64\3\2\2\2\u008a\u008b\7.\2\2\u008b\66\3\2\2\2\u008c"+
		"\u008d\7$\2\2\u008d8\3\2\2\2\u008e\u008f\7@\2\2\u008f:\3\2\2\2\u0090\u0091"+
		"\7>\2\2\u0091<\3\2\2\2\u0092\u0093\7@\2\2\u0093\u0094\7?\2\2\u0094>\3"+
		"\2\2\2\u0095\u0096\7>\2\2\u0096\u0097\7?\2\2\u0097@\3\2\2\2\u0098\u009d"+
		"\t\25\2\2\u0099\u009a\7\17\2\2\u009a\u009d\7\f\2\2\u009b\u009d\7\f\2\2"+
		"\u009c\u0098\3\2\2\2\u009c\u0099\3\2\2\2\u009c\u009b\3\2\2\2\u009d\u009e"+
		"\3\2\2\2\u009e\u009f\b!\2\2\u009fB\3\2\2\2\u00a0\u00a1\5\27\f\2\u00a1"+
		"\u00a2\5\31\r\2\u00a2\u00a3\5\37\20\2\u00a3D\3\2\2\2\u00a4\u00a5\5\3\2"+
		"\2\u00a5\u00a6\5\27\f\2\u00a6\u00a7\5\t\5\2\u00a7F\3\2\2\2\u00a8\u00a9"+
		"\5\31\r\2\u00a9\u00aa\5\33\16\2\u00aaH\3\2\2\2\u00ab\u00ac\5\31\r\2\u00ac"+
		"\u00ad\5\33\16\2\u00ad\u00ae\5\t\5\2\u00ae\u00af\5\13\6\2\u00af\u00b0"+
		"\5\33\16\2\u00b0\u00b1\7\"\2\2\u00b1\u00b2\5\5\3\2\u00b2\u00b3\5!\21\2"+
		"\u00b3J\3\2\2\2\u00b4\u00b5\5\t\5\2\u00b5\u00b6\5\13\6\2\u00b6\u00b7\5"+
		"\35\17\2\u00b7\u00bf\5\7\4\2\u00b8\u00b9\5\13\6\2\u00b9\u00ba\5\27\f\2"+
		"\u00ba\u00bb\5\t\5\2\u00bb\u00bc\5\21\t\2\u00bc\u00bd\5\27\f\2\u00bd\u00be"+
		"\5\r\7\2\u00be\u00c0\3\2\2\2\u00bf\u00b8\3\2\2\2\u00bf\u00c0\3\2\2\2\u00c0"+
		"L\3\2\2\2\u00c1\u00c2\5\3\2\2\u00c2\u00c3\5\35\17\2\u00c3\u00cb\5\7\4"+
		"\2\u00c4\u00c5\5\13\6\2\u00c5\u00c6\5\27\f\2\u00c6\u00c7\5\t\5\2\u00c7"+
		"\u00c8\5\21\t\2\u00c8\u00c9\5\27\f\2\u00c9\u00ca\5\r\7\2\u00ca\u00cc\3"+
		"\2\2\2\u00cb\u00c4\3\2\2\2\u00cb\u00cc\3\2\2\2\u00ccN\3\2\2\2\u00cd\u00d1"+
		"\5#\22\2\u00ce\u00d1\5%\23\2\u00cf\u00d1\7a\2\2\u00d0\u00cd\3\2\2\2\u00d0"+
		"\u00ce\3\2\2\2\u00d0\u00cf\3\2\2\2\u00d1\u00d6\3\2\2\2\u00d2\u00d7\5#"+
		"\22\2\u00d3\u00d7\5%\23\2\u00d4\u00d7\7a\2\2\u00d5\u00d7\5\'\24\2\u00d6"+
		"\u00d2\3\2\2\2\u00d6\u00d3\3\2\2\2\u00d6\u00d4\3\2\2\2\u00d6\u00d5\3\2"+
		"\2\2\u00d7\u00d8\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d8\u00d9\3\2\2\2\u00d9"+
		"P\3\2\2\2\u00da\u00db\n\26\2\2\u00dbR\3\2\2\2\u00dc\u00e2\7$\2\2\u00dd"+
		"\u00e1\n\27\2\2\u00de\u00df\7^\2\2\u00df\u00e1\t\27\2\2\u00e0\u00dd\3"+
		"\2\2\2\u00e0\u00de\3\2\2\2\u00e1\u00e4\3\2\2\2\u00e2\u00e0\3\2\2\2\u00e2"+
		"\u00e3\3\2\2\2\u00e3\u00e5\3\2\2\2\u00e4\u00e2\3\2\2\2\u00e5\u00e6\7$"+
		"\2\2\u00e6T\3\2\2\2\u00e7\u00e8\13\2\2\2\u00e8V\3\2\2\2\13\2\u009c\u00bf"+
		"\u00cb\u00d0\u00d6\u00d8\u00e0\u00e2\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}