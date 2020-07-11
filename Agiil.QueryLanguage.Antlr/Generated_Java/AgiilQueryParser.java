// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/AgiilQuery.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class AgiilQueryParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		BOM=1, OPENPAREN=2, CLOSEPAREN=3, EQUALS=4, NOTEQUALS=5, TILDE=6, COMMA=7, 
		DOUBLEQUOTE=8, GREATERTHAN=9, LESSTHAN=10, GREATERTHANOREQUAL=11, LESSTHANOREQUAL=12, 
		WHITESPACE=13, NOT=14, AND=15, OR=16, ORDERBY=17, DESCENDING=18, ASCENDING=19, 
		NAME=20, WORD=21, QUOTEDVALUE=22, ANY=23;
	public static final int
		RULE_search = 0, RULE_criteria = 1, RULE_logicalcriteriagroups = 2, RULE_criterionorgroup = 3, 
		RULE_criteriagroup = 4, RULE_criterion = 5, RULE_elementtest = 6, RULE_logicaloperator = 7, 
		RULE_element = 8, RULE_predicate = 9, RULE_predicatename = 10, RULE_comparison = 11, 
		RULE_value = 12, RULE_constantvalue = 13, RULE_functioninvocation = 14, 
		RULE_functionparameters = 15, RULE_orders = 16, RULE_orderelement = 17;
	public static final String[] ruleNames = {
		"search", "criteria", "logicalcriteriagroups", "criterionorgroup", "criteriagroup", 
		"criterion", "elementtest", "logicaloperator", "element", "predicate", 
		"predicatename", "comparison", "value", "constantvalue", "functioninvocation", 
		"functionparameters", "orders", "orderelement"
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

	@Override
	public String getGrammarFileName() { return "AgiilQuery.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public AgiilQueryParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class SearchContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(AgiilQueryParser.EOF, 0); }
		public TerminalNode BOM() { return getToken(AgiilQueryParser.BOM, 0); }
		public CriteriaContext criteria() {
			return getRuleContext(CriteriaContext.class,0);
		}
		public OrdersContext orders() {
			return getRuleContext(OrdersContext.class,0);
		}
		public SearchContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_search; }
	}

	public final SearchContext search() throws RecognitionException {
		SearchContext _localctx = new SearchContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_search);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(37);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==BOM) {
				{
				setState(36);
				match(BOM);
				}
			}

			setState(40);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPENPAREN || _la==NAME) {
				{
				setState(39);
				criteria();
				}
			}

			setState(43);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDERBY) {
				{
				setState(42);
				orders();
				}
			}

			setState(45);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriteriaContext extends ParserRuleContext {
		public LogicalcriteriagroupsContext logicalcriteriagroups() {
			return getRuleContext(LogicalcriteriagroupsContext.class,0);
		}
		public CriteriaContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criteria; }
	}

	public final CriteriaContext criteria() throws RecognitionException {
		CriteriaContext _localctx = new CriteriaContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_criteria);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(47);
			logicalcriteriagroups();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LogicalcriteriagroupsContext extends ParserRuleContext {
		public List<CriterionorgroupContext> criterionorgroup() {
			return getRuleContexts(CriterionorgroupContext.class);
		}
		public CriterionorgroupContext criterionorgroup(int i) {
			return getRuleContext(CriterionorgroupContext.class,i);
		}
		public List<LogicaloperatorContext> logicaloperator() {
			return getRuleContexts(LogicaloperatorContext.class);
		}
		public LogicaloperatorContext logicaloperator(int i) {
			return getRuleContext(LogicaloperatorContext.class,i);
		}
		public LogicalcriteriagroupsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicalcriteriagroups; }
	}

	public final LogicalcriteriagroupsContext logicalcriteriagroups() throws RecognitionException {
		LogicalcriteriagroupsContext _localctx = new LogicalcriteriagroupsContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_logicalcriteriagroups);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(49);
			criterionorgroup();
			setState(56);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPENPAREN) | (1L << AND) | (1L << OR) | (1L << NAME))) != 0)) {
				{
				{
				setState(51);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AND || _la==OR) {
					{
					setState(50);
					logicaloperator();
					}
				}

				setState(53);
				criterionorgroup();
				}
				}
				setState(58);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriterionorgroupContext extends ParserRuleContext {
		public CriterionContext criterion() {
			return getRuleContext(CriterionContext.class,0);
		}
		public CriteriagroupContext criteriagroup() {
			return getRuleContext(CriteriagroupContext.class,0);
		}
		public CriterionorgroupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criterionorgroup; }
	}

	public final CriterionorgroupContext criterionorgroup() throws RecognitionException {
		CriterionorgroupContext _localctx = new CriterionorgroupContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_criterionorgroup);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(61);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				{
				setState(59);
				criterion();
				}
				break;
			case OPENPAREN:
				{
				setState(60);
				criteriagroup();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriteriagroupContext extends ParserRuleContext {
		public TerminalNode OPENPAREN() { return getToken(AgiilQueryParser.OPENPAREN, 0); }
		public LogicalcriteriagroupsContext logicalcriteriagroups() {
			return getRuleContext(LogicalcriteriagroupsContext.class,0);
		}
		public TerminalNode CLOSEPAREN() { return getToken(AgiilQueryParser.CLOSEPAREN, 0); }
		public CriteriagroupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criteriagroup; }
	}

	public final CriteriagroupContext criteriagroup() throws RecognitionException {
		CriteriagroupContext _localctx = new CriteriagroupContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_criteriagroup);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(63);
			match(OPENPAREN);
			setState(64);
			logicalcriteriagroups();
			setState(65);
			match(CLOSEPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriterionContext extends ParserRuleContext {
		public ElementContext element() {
			return getRuleContext(ElementContext.class,0);
		}
		public ElementtestContext elementtest() {
			return getRuleContext(ElementtestContext.class,0);
		}
		public CriterionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criterion; }
	}

	public final CriterionContext criterion() throws RecognitionException {
		CriterionContext _localctx = new CriterionContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_criterion);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(67);
			element();
			setState(68);
			elementtest();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElementtestContext extends ParserRuleContext {
		public PredicateContext predicate() {
			return getRuleContext(PredicateContext.class,0);
		}
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public FunctioninvocationContext functioninvocation() {
			return getRuleContext(FunctioninvocationContext.class,0);
		}
		public TerminalNode NOT() { return getToken(AgiilQueryParser.NOT, 0); }
		public ElementtestContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elementtest; }
	}

	public final ElementtestContext elementtest() throws RecognitionException {
		ElementtestContext _localctx = new ElementtestContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_elementtest);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(77);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				{
				{
				setState(70);
				predicate();
				setState(71);
				value();
				}
				}
				break;
			case 2:
				{
				{
				setState(74);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(73);
					match(NOT);
					}
				}

				setState(76);
				functioninvocation();
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LogicaloperatorContext extends ParserRuleContext {
		public TerminalNode AND() { return getToken(AgiilQueryParser.AND, 0); }
		public TerminalNode OR() { return getToken(AgiilQueryParser.OR, 0); }
		public LogicaloperatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicaloperator; }
	}

	public final LogicaloperatorContext logicaloperator() throws RecognitionException {
		LogicaloperatorContext _localctx = new LogicaloperatorContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_logicaloperator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(79);
			_la = _input.LA(1);
			if ( !(_la==AND || _la==OR) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElementContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public ElementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_element; }
	}

	public final ElementContext element() throws RecognitionException {
		ElementContext _localctx = new ElementContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_element);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(81);
			match(NAME);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredicateContext extends ParserRuleContext {
		public PredicatenameContext predicatename() {
			return getRuleContext(PredicatenameContext.class,0);
		}
		public TerminalNode NOT() { return getToken(AgiilQueryParser.NOT, 0); }
		public PredicateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicate; }
	}

	public final PredicateContext predicate() throws RecognitionException {
		PredicateContext _localctx = new PredicateContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_predicate);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(84);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NOT) {
				{
				setState(83);
				match(NOT);
				}
			}

			setState(86);
			predicatename();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredicatenameContext extends ParserRuleContext {
		public TerminalNode EQUALS() { return getToken(AgiilQueryParser.EQUALS, 0); }
		public TerminalNode NOTEQUALS() { return getToken(AgiilQueryParser.NOTEQUALS, 0); }
		public TerminalNode TILDE() { return getToken(AgiilQueryParser.TILDE, 0); }
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public ComparisonContext comparison() {
			return getRuleContext(ComparisonContext.class,0);
		}
		public PredicatenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicatename; }
	}

	public final PredicatenameContext predicatename() throws RecognitionException {
		PredicatenameContext _localctx = new PredicatenameContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_predicatename);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(93);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case EQUALS:
				{
				setState(88);
				match(EQUALS);
				}
				break;
			case NOTEQUALS:
				{
				setState(89);
				match(NOTEQUALS);
				}
				break;
			case TILDE:
				{
				setState(90);
				match(TILDE);
				}
				break;
			case NAME:
				{
				setState(91);
				match(NAME);
				}
				break;
			case GREATERTHAN:
			case LESSTHAN:
			case GREATERTHANOREQUAL:
			case LESSTHANOREQUAL:
				{
				setState(92);
				comparison();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ComparisonContext extends ParserRuleContext {
		public TerminalNode GREATERTHAN() { return getToken(AgiilQueryParser.GREATERTHAN, 0); }
		public TerminalNode LESSTHAN() { return getToken(AgiilQueryParser.LESSTHAN, 0); }
		public TerminalNode GREATERTHANOREQUAL() { return getToken(AgiilQueryParser.GREATERTHANOREQUAL, 0); }
		public TerminalNode LESSTHANOREQUAL() { return getToken(AgiilQueryParser.LESSTHANOREQUAL, 0); }
		public ComparisonContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_comparison; }
	}

	public final ComparisonContext comparison() throws RecognitionException {
		ComparisonContext _localctx = new ComparisonContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_comparison);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(95);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << GREATERTHAN) | (1L << LESSTHAN) | (1L << GREATERTHANOREQUAL) | (1L << LESSTHANOREQUAL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ValueContext extends ParserRuleContext {
		public ConstantvalueContext constantvalue() {
			return getRuleContext(ConstantvalueContext.class,0);
		}
		public FunctioninvocationContext functioninvocation() {
			return getRuleContext(FunctioninvocationContext.class,0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				{
				setState(97);
				constantvalue();
				}
				break;
			case 2:
				{
				setState(98);
				functioninvocation();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantvalueContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public TerminalNode NOT() { return getToken(AgiilQueryParser.NOT, 0); }
		public TerminalNode AND() { return getToken(AgiilQueryParser.AND, 0); }
		public TerminalNode OR() { return getToken(AgiilQueryParser.OR, 0); }
		public TerminalNode DESCENDING() { return getToken(AgiilQueryParser.DESCENDING, 0); }
		public TerminalNode ASCENDING() { return getToken(AgiilQueryParser.ASCENDING, 0); }
		public TerminalNode QUOTEDVALUE() { return getToken(AgiilQueryParser.QUOTEDVALUE, 0); }
		public List<TerminalNode> WORD() { return getTokens(AgiilQueryParser.WORD); }
		public TerminalNode WORD(int i) {
			return getToken(AgiilQueryParser.WORD, i);
		}
		public ConstantvalueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constantvalue; }
	}

	public final ConstantvalueContext constantvalue() throws RecognitionException {
		ConstantvalueContext _localctx = new ConstantvalueContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_constantvalue);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				{
				setState(101);
				match(NAME);
				}
				break;
			case NOT:
				{
				setState(102);
				match(NOT);
				}
				break;
			case AND:
				{
				setState(103);
				match(AND);
				}
				break;
			case OR:
				{
				setState(104);
				match(OR);
				}
				break;
			case WORD:
				{
				setState(106); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(105);
					match(WORD);
					}
					}
					setState(108); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==WORD );
				}
				break;
			case DESCENDING:
				{
				setState(110);
				match(DESCENDING);
				}
				break;
			case ASCENDING:
				{
				setState(111);
				match(ASCENDING);
				}
				break;
			case QUOTEDVALUE:
				{
				setState(112);
				match(QUOTEDVALUE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctioninvocationContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public TerminalNode OPENPAREN() { return getToken(AgiilQueryParser.OPENPAREN, 0); }
		public FunctionparametersContext functionparameters() {
			return getRuleContext(FunctionparametersContext.class,0);
		}
		public TerminalNode CLOSEPAREN() { return getToken(AgiilQueryParser.CLOSEPAREN, 0); }
		public FunctioninvocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functioninvocation; }
	}

	public final FunctioninvocationContext functioninvocation() throws RecognitionException {
		FunctioninvocationContext _localctx = new FunctioninvocationContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_functioninvocation);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(115);
			match(NAME);
			setState(116);
			match(OPENPAREN);
			setState(117);
			functionparameters();
			setState(118);
			match(CLOSEPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionparametersContext extends ParserRuleContext {
		public List<ValueContext> value() {
			return getRuleContexts(ValueContext.class);
		}
		public ValueContext value(int i) {
			return getRuleContext(ValueContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(AgiilQueryParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(AgiilQueryParser.COMMA, i);
		}
		public FunctionparametersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionparameters; }
	}

	public final FunctionparametersContext functionparameters() throws RecognitionException {
		FunctionparametersContext _localctx = new FunctionparametersContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_functionparameters);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(128);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NOT) | (1L << AND) | (1L << OR) | (1L << DESCENDING) | (1L << ASCENDING) | (1L << NAME) | (1L << WORD) | (1L << QUOTEDVALUE))) != 0)) {
				{
				setState(120);
				value();
				setState(125);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(121);
					match(COMMA);
					setState(122);
					value();
					}
					}
					setState(127);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OrdersContext extends ParserRuleContext {
		public TerminalNode ORDERBY() { return getToken(AgiilQueryParser.ORDERBY, 0); }
		public List<OrderelementContext> orderelement() {
			return getRuleContexts(OrderelementContext.class);
		}
		public OrderelementContext orderelement(int i) {
			return getRuleContext(OrderelementContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(AgiilQueryParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(AgiilQueryParser.COMMA, i);
		}
		public OrdersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_orders; }
	}

	public final OrdersContext orders() throws RecognitionException {
		OrdersContext _localctx = new OrdersContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_orders);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			match(ORDERBY);
			setState(131);
			orderelement();
			setState(136);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(132);
				match(COMMA);
				setState(133);
				orderelement();
				}
				}
				setState(138);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OrderelementContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public FunctioninvocationContext functioninvocation() {
			return getRuleContext(FunctioninvocationContext.class,0);
		}
		public TerminalNode ASCENDING() { return getToken(AgiilQueryParser.ASCENDING, 0); }
		public TerminalNode DESCENDING() { return getToken(AgiilQueryParser.DESCENDING, 0); }
		public OrderelementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_orderelement; }
	}

	public final OrderelementContext orderelement() throws RecognitionException {
		OrderelementContext _localctx = new OrderelementContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_orderelement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(141);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				setState(139);
				match(NAME);
				}
				break;
			case 2:
				{
				setState(140);
				functioninvocation();
				}
				break;
			}
			setState(144);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==DESCENDING || _la==ASCENDING) {
				{
				setState(143);
				_la = _input.LA(1);
				if ( !(_la==DESCENDING || _la==ASCENDING) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\31\u0095\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\3\2\5\2(\n\2\3\2\5\2+\n\2\3\2\5\2.\n\2\3\2\3\2\3\3\3\3\3\4"+
		"\3\4\5\4\66\n\4\3\4\7\49\n\4\f\4\16\4<\13\4\3\5\3\5\5\5@\n\5\3\6\3\6\3"+
		"\6\3\6\3\7\3\7\3\7\3\b\3\b\3\b\3\b\5\bM\n\b\3\b\5\bP\n\b\3\t\3\t\3\n\3"+
		"\n\3\13\5\13W\n\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\5\f`\n\f\3\r\3\r\3\16"+
		"\3\16\5\16f\n\16\3\17\3\17\3\17\3\17\3\17\6\17m\n\17\r\17\16\17n\3\17"+
		"\3\17\3\17\5\17t\n\17\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3\21\7\21~\n"+
		"\21\f\21\16\21\u0081\13\21\5\21\u0083\n\21\3\22\3\22\3\22\3\22\7\22\u0089"+
		"\n\22\f\22\16\22\u008c\13\22\3\23\3\23\5\23\u0090\n\23\3\23\5\23\u0093"+
		"\n\23\3\23\2\2\24\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$\2\5\3\2\21"+
		"\22\3\2\13\16\3\2\24\25\2\u009d\2\'\3\2\2\2\4\61\3\2\2\2\6\63\3\2\2\2"+
		"\b?\3\2\2\2\nA\3\2\2\2\fE\3\2\2\2\16O\3\2\2\2\20Q\3\2\2\2\22S\3\2\2\2"+
		"\24V\3\2\2\2\26_\3\2\2\2\30a\3\2\2\2\32e\3\2\2\2\34s\3\2\2\2\36u\3\2\2"+
		"\2 \u0082\3\2\2\2\"\u0084\3\2\2\2$\u008f\3\2\2\2&(\7\3\2\2\'&\3\2\2\2"+
		"\'(\3\2\2\2(*\3\2\2\2)+\5\4\3\2*)\3\2\2\2*+\3\2\2\2+-\3\2\2\2,.\5\"\22"+
		"\2-,\3\2\2\2-.\3\2\2\2./\3\2\2\2/\60\7\2\2\3\60\3\3\2\2\2\61\62\5\6\4"+
		"\2\62\5\3\2\2\2\63:\5\b\5\2\64\66\5\20\t\2\65\64\3\2\2\2\65\66\3\2\2\2"+
		"\66\67\3\2\2\2\679\5\b\5\28\65\3\2\2\29<\3\2\2\2:8\3\2\2\2:;\3\2\2\2;"+
		"\7\3\2\2\2<:\3\2\2\2=@\5\f\7\2>@\5\n\6\2?=\3\2\2\2?>\3\2\2\2@\t\3\2\2"+
		"\2AB\7\4\2\2BC\5\6\4\2CD\7\5\2\2D\13\3\2\2\2EF\5\22\n\2FG\5\16\b\2G\r"+
		"\3\2\2\2HI\5\24\13\2IJ\5\32\16\2JP\3\2\2\2KM\7\20\2\2LK\3\2\2\2LM\3\2"+
		"\2\2MN\3\2\2\2NP\5\36\20\2OH\3\2\2\2OL\3\2\2\2P\17\3\2\2\2QR\t\2\2\2R"+
		"\21\3\2\2\2ST\7\26\2\2T\23\3\2\2\2UW\7\20\2\2VU\3\2\2\2VW\3\2\2\2WX\3"+
		"\2\2\2XY\5\26\f\2Y\25\3\2\2\2Z`\7\6\2\2[`\7\7\2\2\\`\7\b\2\2]`\7\26\2"+
		"\2^`\5\30\r\2_Z\3\2\2\2_[\3\2\2\2_\\\3\2\2\2_]\3\2\2\2_^\3\2\2\2`\27\3"+
		"\2\2\2ab\t\3\2\2b\31\3\2\2\2cf\5\34\17\2df\5\36\20\2ec\3\2\2\2ed\3\2\2"+
		"\2f\33\3\2\2\2gt\7\26\2\2ht\7\20\2\2it\7\21\2\2jt\7\22\2\2km\7\27\2\2"+
		"lk\3\2\2\2mn\3\2\2\2nl\3\2\2\2no\3\2\2\2ot\3\2\2\2pt\7\24\2\2qt\7\25\2"+
		"\2rt\7\30\2\2sg\3\2\2\2sh\3\2\2\2si\3\2\2\2sj\3\2\2\2sl\3\2\2\2sp\3\2"+
		"\2\2sq\3\2\2\2sr\3\2\2\2t\35\3\2\2\2uv\7\26\2\2vw\7\4\2\2wx\5 \21\2xy"+
		"\7\5\2\2y\37\3\2\2\2z\177\5\32\16\2{|\7\t\2\2|~\5\32\16\2}{\3\2\2\2~\u0081"+
		"\3\2\2\2\177}\3\2\2\2\177\u0080\3\2\2\2\u0080\u0083\3\2\2\2\u0081\177"+
		"\3\2\2\2\u0082z\3\2\2\2\u0082\u0083\3\2\2\2\u0083!\3\2\2\2\u0084\u0085"+
		"\7\23\2\2\u0085\u008a\5$\23\2\u0086\u0087\7\t\2\2\u0087\u0089\5$\23\2"+
		"\u0088\u0086\3\2\2\2\u0089\u008c\3\2\2\2\u008a\u0088\3\2\2\2\u008a\u008b"+
		"\3\2\2\2\u008b#\3\2\2\2\u008c\u008a\3\2\2\2\u008d\u0090\7\26\2\2\u008e"+
		"\u0090\5\36\20\2\u008f\u008d\3\2\2\2\u008f\u008e\3\2\2\2\u0090\u0092\3"+
		"\2\2\2\u0091\u0093\t\4\2\2\u0092\u0091\3\2\2\2\u0092\u0093\3\2\2\2\u0093"+
		"%\3\2\2\2\24\'*-\65:?LOV_ens\177\u0082\u008a\u008f\u0092";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}