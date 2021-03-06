﻿using Newtonsoft.Json;

namespace Nest
{
	/// <summary>
	/// Information based model similarity.
	/// The algorithm is based on the concept that the information content in any symbolic distribution sequence
	/// is primarily determined by the repetitive usage of its basic elements.
	/// For written texts this challenge would correspond to comparing the writing styles of different authors.
	/// </summary>
	public interface IIBSimilarity : ISimilarity
	{
		/// <summary>
		/// The distribution
		/// </summary>
		[JsonProperty("distribution")]
		IBDistribution? Distribution { get; set; }

		/// <summary>
		/// The lambda
		/// </summary>
		[JsonProperty("lambda")]
		IBLambda? Lambda { get; set; }

		/// <summary>
		/// The normalization
		/// </summary>
		[JsonProperty("normalization")]
		Normalization? Normalization { get; set; }

		/// <summary>
		/// Normalization model that assumes a uniform distribution of the term frequency. 
		/// </summary>
		[JsonProperty("normalization.h1.c")]
		double? NormalizationH1C { get; set; }

		/// <summary>
		///  Normalization model in which the term frequency is inversely related to the length.
		/// </summary>
		[JsonProperty("normalization.h2.c")]
		double? NormalizationH2C { get; set; }

		/// <summary>
		///  Dirichlet Priors normalization
		/// </summary>
		[JsonProperty("normalization.h3.c")]
		double? NormalizationH3C { get; set; }

		/// <summary>
		/// Pareto-Zipf Normalization
		/// </summary>
		[JsonProperty("normalization.z.z")]
		double? NormalizationZZ { get; set; }
	}

	/// <inheritdoc/>
	public class IBSimilarity : IIBSimilarity
	{
		public string Type => "IB";

		/// <inheritdoc/>
		public IBDistribution? Distribution { get; set; }

		/// <inheritdoc/>
		public IBLambda? Lambda { get; set; }

		/// <inheritdoc/>
		public Normalization? Normalization { get; set; }

		/// <inheritdoc/>
		public double? NormalizationH1C { get; set; }

		/// <inheritdoc/>
		public double? NormalizationH2C { get; set; }

		/// <inheritdoc/>
		public double? NormalizationH3C { get; set; }

		/// <inheritdoc/>
		public double? NormalizationZZ { get; set; }
	}

	/// <inheritdoc/>
	public class IBSimilarityDescriptor
		: DescriptorBase<IBSimilarityDescriptor, IIBSimilarity>, IIBSimilarity
	{
		string ISimilarity.Type => "IB";
		IBDistribution? IIBSimilarity.Distribution { get; set; }
		IBLambda? IIBSimilarity.Lambda { get; set; }
		Normalization? IIBSimilarity.Normalization { get; set; }
		double? IIBSimilarity.NormalizationH1C { get; set; }
		double? IIBSimilarity.NormalizationH2C { get; set; }
		double? IIBSimilarity.NormalizationH3C { get; set; }
		double? IIBSimilarity.NormalizationZZ { get; set; }

		/// <inheritdoc/>
		public IBSimilarityDescriptor Distribution(IBDistribution? distribution) => Assign(a => a.Distribution = distribution);

		/// <inheritdoc/>
		public IBSimilarityDescriptor Lambda(IBLambda? lambda) => Assign(a => a.Lambda = lambda);

		/// <inheritdoc/>
		public IBSimilarityDescriptor NoNormalization() => Assign(a => a.Normalization = Normalization.No);

		/// <summary>
		/// Normalization model that assumes a uniform distribution of the term frequency. 
		/// </summary>
		/// <param name="c">hyper-parameter that controls the term frequency normalization with respect to the document length.</param>
		public IBSimilarityDescriptor NormalizationH1(double? c) => Assign(a =>
		{
			a.Normalization = Normalization.H1;
			a.NormalizationH1C = c;
		});

		/// <summary>
		/// Normalization model in which the term frequency is inversely related to the length.
		/// </summary>
		/// <param name="c">hyper-parameter that controls the term frequency normalization with respect to the document length.</param>
		public IBSimilarityDescriptor NormalizationH2(double? c) => Assign(a =>
		{
			a.Normalization = Normalization.H2;
			a.NormalizationH1C = c;
		});

		/// <summary>
		/// Dirichlet Priors normalization
		/// </summary>
		/// <param name="mu">smoothing parameter μ.</param>
		public IBSimilarityDescriptor NormalizationH3(double? mu) => Assign(a =>
		{
			a.Normalization = Normalization.H3;
			a.NormalizationH1C = mu;
		});

		/// <summary>
		/// Pareto-Zipf Normalization
		/// </summary>
		/// <param name="mu">represents A/(A+1) where A measures the specificity of the language..</param>
		public IBSimilarityDescriptor NormalizationZ(double? z) => Assign(a =>
		{
			a.Normalization = Normalization.Z;
			a.NormalizationH1C = z;
		});
	}

}
