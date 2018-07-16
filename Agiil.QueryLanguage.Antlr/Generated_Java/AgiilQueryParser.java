// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/Tools/../AgiilQuery.g4 by ANTLR 4.7.1
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
		OPENPAREN=1, CLOSEPAREN=2, EQUALS=3, NOTEQUALS=4, TILDE=5, COMMA=6, WHITESPACE=7, 
		NOT=8, AND=9, OR=10, NAME=11, WORD=12, DIGITS=13, QUOTEDVALUE=14, ANY=15;
	public static final int
		RULE_criteria = 0, RULE_logicalcriteriagroups = 1, RULE_criterionorgroup = 2, 
		RULE_criteriagroup = 3, RULE_criterion = 4, RULE_elementtest = 5, RULE_logicalcombination = 6, 
		RULE_element = 7, RULE_predicate = 8, RULE_predicatename = 9, RULE_value = 10, 
		RULE_constantvalue = 11, RULE_functioninvocation = 12, RULE_functionparameters = 13;
	public static final String[] ruleNames = {
		"criteria", "logicalcriteriagroups", "criterionorgroup", "criteriagroup", 
		"criterion", "elementtest", "logicalcombination", "element", "predicate", 
		"predicatename", "value", "constantvalue", "functioninvocation", "functionparameters"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'('", "')'", "'='", "'!='", "'~'", "','"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "OPENPAREN", "CLOSEPAREN", "EQUALS", "NOTEQUALS", "TILDE", "COMMA", 
		"WHITESPACE", "NOT", "AND", "OR", "NAME", "WORD", "DIGITS", "QUOTEDVALUE", 
		"ANY"
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
	public static class CriteriaContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(AgiilQueryParser.EOF, 0); }
		public LogicalcriteriagroupsContext logicalcriteriagroups() {
			return getRuleContext(LogicalcriteriagroupsContext.class,0);
		}
		public List<TerminalNode> WHITESPACE() { return getTokens(AgiilQueryParser.WHITESPACE); }
		public TerminalNode WHITESPACE(int i) {
			return getToken(AgiilQueryParser.WHITESPACE, i);
		}
		public CriteriaContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criteria; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriteria(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriteriaContext criteria() throws RecognitionException {
		CriteriaContext _localctx = new CriteriaContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_criteria);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(29);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPENPAREN || _la==NAME) {
				{
				setState(28);
				logicalcriteriagroups();
				}
			}

			setState(34);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==WHITESPACE) {
				{
				{
				setState(31);
				match(WHITESPACE);
				}
				}
				setState(36);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(37);
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

	public static class LogicalcriteriagroupsContext extends ParserRuleContext {
		public List<CriterionorgroupContext> criterionorgroup() {
			return getRuleContexts(CriterionorgroupContext.class);
		}
		public CriterionorgroupContext criterionorgroup(int i) {
			return getRuleContext(CriterionorgroupContext.class,i);
		}
		public List<LogicalcombinationContext> logicalcombination() {
			return getRuleContexts(LogicalcombinationContext.class);
		}
		public LogicalcombinationContext logicalcombination(int i) {
			return getRuleContext(LogicalcombinationContext.class,i);
		}
		public LogicalcriteriagroupsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicalcriteriagroups; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitLogicalcriteriagroups(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LogicalcriteriagroupsContext logicalcriteriagroups() throws RecognitionException {
		LogicalcriteriagroupsContext _localctx = new LogicalcriteriagroupsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_logicalcriteriagroups);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(39);
			criterionorgroup();
			setState(46);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPENPAREN) | (1L << AND) | (1L << OR) | (1L << NAME))) != 0)) {
				{
				{
				setState(41);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AND || _la==OR) {
					{
					setState(40);
					logicalcombination();
					}
				}

				setState(43);
				criterionorgroup();
				}
				}
				setState(48);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriterionorgroup(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriterionorgroupContext criterionorgroup() throws RecognitionException {
		CriterionorgroupContext _localctx = new CriterionorgroupContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_criterionorgroup);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(51);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				{
				setState(49);
				criterion();
				}
				break;
			case OPENPAREN:
				{
				setState(50);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriteriagroup(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriteriagroupContext criteriagroup() throws RecognitionException {
		CriteriagroupContext _localctx = new CriteriagroupContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_criteriagroup);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(53);
			match(OPENPAREN);
			setState(54);
			logicalcriteriagroups();
			setState(55);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriterion(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriterionContext criterion() throws RecognitionException {
		CriterionContext _localctx = new CriterionContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_criterion);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(57);
			element();
			setState(58);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitElementtest(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ElementtestContext elementtest() throws RecognitionException {
		ElementtestContext _localctx = new ElementtestContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_elementtest);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(67);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				{
				{
				setState(60);
				predicate();
				setState(61);
				value();
				}
				}
				break;
			case 2:
				{
				{
				setState(64);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(63);
					match(NOT);
					}
				}

				setState(66);
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

	public static class LogicalcombinationContext extends ParserRuleContext {
		public TerminalNode AND() { return getToken(AgiilQueryParser.AND, 0); }
		public TerminalNode OR() { return getToken(AgiilQueryParser.OR, 0); }
		public LogicalcombinationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicalcombination; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitLogicalcombination(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LogicalcombinationContext logicalcombination() throws RecognitionException {
		LogicalcombinationContext _localctx = new LogicalcombinationContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_logicalcombination);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(69);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitElement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ElementContext element() throws RecognitionException {
		ElementContext _localctx = new ElementContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_element);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(71);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitPredicate(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PredicateContext predicate() throws RecognitionException {
		PredicateContext _localctx = new PredicateContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_predicate);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
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
		public PredicatenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicatename; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitPredicatename(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PredicatenameContext predicatename() throws RecognitionException {
		PredicatenameContext _localctx = new PredicatenameContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_predicatename);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(78);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQUALS) | (1L << NOTEQUALS) | (1L << TILDE) | (1L << NAME))) != 0)) ) {
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitValue(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(82);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(80);
				constantvalue();
				}
				break;
			case 2:
				{
				setState(81);
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
		public TerminalNode QUOTEDVALUE() { return getToken(AgiilQueryParser.QUOTEDVALUE, 0); }
		public List<TerminalNode> WORD() { return getTokens(AgiilQueryParser.WORD); }
		public TerminalNode WORD(int i) {
			return getToken(AgiilQueryParser.WORD, i);
		}
		public List<TerminalNode> DIGITS() { return getTokens(AgiilQueryParser.DIGITS); }
		public TerminalNode DIGITS(int i) {
			return getToken(AgiilQueryParser.DIGITS, i);
		}
		public ConstantvalueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constantvalue; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitConstantvalue(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ConstantvalueContext constantvalue() throws RecognitionException {
		ConstantvalueContext _localctx = new ConstantvalueContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_constantvalue);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(91);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				{
				setState(84);
				match(NAME);
				}
				break;
			case WORD:
			case DIGITS:
				{
				setState(86); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(85);
					_la = _input.LA(1);
					if ( !(_la==WORD || _la==DIGITS) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
					}
					setState(88); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==WORD || _la==DIGITS );
				}
				break;
			case QUOTEDVALUE:
				{
				setState(90);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitFunctioninvocation(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FunctioninvocationContext functioninvocation() throws RecognitionException {
		FunctioninvocationContext _localctx = new FunctioninvocationContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_functioninvocation);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(93);
			match(NAME);
			setState(94);
			match(OPENPAREN);
			setState(95);
			functionparameters();
			setState(96);
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
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitFunctionparameters(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FunctionparametersContext functionparameters() throws RecognitionException {
		FunctionparametersContext _localctx = new FunctionparametersContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_functionparameters);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(106);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NAME) | (1L << WORD) | (1L << DIGITS) | (1L << QUOTEDVALUE))) != 0)) {
				{
				setState(98);
				value();
				setState(103);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(99);
					match(COMMA);
					setState(100);
					value();
					}
					}
					setState(105);
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

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\21o\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t\13\4"+
		"\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\3\2\5\2 \n\2\3\2\7\2#\n\2\f\2\16\2"+
		"&\13\2\3\2\3\2\3\3\3\3\5\3,\n\3\3\3\7\3/\n\3\f\3\16\3\62\13\3\3\4\3\4"+
		"\5\4\66\n\4\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\7\3\7\3\7\3\7\5\7C\n\7\3\7\5"+
		"\7F\n\7\3\b\3\b\3\t\3\t\3\n\5\nM\n\n\3\n\3\n\3\13\3\13\3\f\3\f\5\fU\n"+
		"\f\3\r\3\r\6\rY\n\r\r\r\16\rZ\3\r\5\r^\n\r\3\16\3\16\3\16\3\16\3\16\3"+
		"\17\3\17\3\17\7\17h\n\17\f\17\16\17k\13\17\5\17m\n\17\3\17\2\2\20\2\4"+
		"\6\b\n\f\16\20\22\24\26\30\32\34\2\5\3\2\13\f\4\2\5\7\r\r\3\2\16\17\2"+
		"n\2\37\3\2\2\2\4)\3\2\2\2\6\65\3\2\2\2\b\67\3\2\2\2\n;\3\2\2\2\fE\3\2"+
		"\2\2\16G\3\2\2\2\20I\3\2\2\2\22L\3\2\2\2\24P\3\2\2\2\26T\3\2\2\2\30]\3"+
		"\2\2\2\32_\3\2\2\2\34l\3\2\2\2\36 \5\4\3\2\37\36\3\2\2\2\37 \3\2\2\2 "+
		"$\3\2\2\2!#\7\t\2\2\"!\3\2\2\2#&\3\2\2\2$\"\3\2\2\2$%\3\2\2\2%\'\3\2\2"+
		"\2&$\3\2\2\2\'(\7\2\2\3(\3\3\2\2\2)\60\5\6\4\2*,\5\16\b\2+*\3\2\2\2+,"+
		"\3\2\2\2,-\3\2\2\2-/\5\6\4\2.+\3\2\2\2/\62\3\2\2\2\60.\3\2\2\2\60\61\3"+
		"\2\2\2\61\5\3\2\2\2\62\60\3\2\2\2\63\66\5\n\6\2\64\66\5\b\5\2\65\63\3"+
		"\2\2\2\65\64\3\2\2\2\66\7\3\2\2\2\678\7\3\2\289\5\4\3\29:\7\4\2\2:\t\3"+
		"\2\2\2;<\5\20\t\2<=\5\f\7\2=\13\3\2\2\2>?\5\22\n\2?@\5\26\f\2@F\3\2\2"+
		"\2AC\7\n\2\2BA\3\2\2\2BC\3\2\2\2CD\3\2\2\2DF\5\32\16\2E>\3\2\2\2EB\3\2"+
		"\2\2F\r\3\2\2\2GH\t\2\2\2H\17\3\2\2\2IJ\7\r\2\2J\21\3\2\2\2KM\7\n\2\2"+
		"LK\3\2\2\2LM\3\2\2\2MN\3\2\2\2NO\5\24\13\2O\23\3\2\2\2PQ\t\3\2\2Q\25\3"+
		"\2\2\2RU\5\30\r\2SU\5\32\16\2TR\3\2\2\2TS\3\2\2\2U\27\3\2\2\2V^\7\r\2"+
		"\2WY\t\4\2\2XW\3\2\2\2YZ\3\2\2\2ZX\3\2\2\2Z[\3\2\2\2[^\3\2\2\2\\^\7\20"+
		"\2\2]V\3\2\2\2]X\3\2\2\2]\\\3\2\2\2^\31\3\2\2\2_`\7\r\2\2`a\7\3\2\2ab"+
		"\5\34\17\2bc\7\4\2\2c\33\3\2\2\2di\5\26\f\2ef\7\b\2\2fh\5\26\f\2ge\3\2"+
		"\2\2hk\3\2\2\2ig\3\2\2\2ij\3\2\2\2jm\3\2\2\2ki\3\2\2\2ld\3\2\2\2lm\3\2"+
		"\2\2m\35\3\2\2\2\17\37$+\60\65BELTZ]il";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}