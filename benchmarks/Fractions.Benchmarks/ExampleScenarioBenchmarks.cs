using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
// [ShortRunJob]
[MediumRunJob(RuntimeMoniker.Net48)]
[MediumRunJob(RuntimeMoniker.Net80)]
public class ExampleScenarioBenchmarks {
    private Dictionary<MedicineRecord, List<InfusionRateRangeRecord>> MedicineRecords { get; set; }
    private List<PatientAppointmentRecord> PatientAppointmentRecords { get; set; }


    [GlobalSetup]
    public void GlobalSetup() {
        var chemical1 = new MedicineRecord { Id = 1, Description = "Propofol 2%", MassConcentrationMgMl = 20.00m };
        var chemical2 = new MedicineRecord { Id = 2, Description = "Sufentanil", MassConcentrationMgMl = 0.010m };
        var chemical3 = new MedicineRecord { Id = 3, Description = "Clonidin", MassConcentrationMgMl = 0.018m };
        MedicineRecords = new Dictionary<MedicineRecord, List<InfusionRateRangeRecord>> {
            {
                chemical1, [
                    new InfusionRateRangeRecord { MinWeight = 50, MaxWeight = 60, InfusionRateMgKgH = 4.7500m },
                    new InfusionRateRangeRecord { MinWeight = 60, MaxWeight = 70, InfusionRateMgKgH = 4.8000m },
                    new InfusionRateRangeRecord { MinWeight = 70, MaxWeight = 80, InfusionRateMgKgH = 4.8500m },
                    new InfusionRateRangeRecord { MinWeight = 80, MaxWeight = 90, InfusionRateMgKgH = 4.9500m },
                    new InfusionRateRangeRecord { MinWeight = 90, MaxWeight = 99, InfusionRateMgKgH = 5.0000m }
                ]
            }, {
                chemical2, [
                    new InfusionRateRangeRecord { MinWeight = 50, MaxWeight = 60, InfusionRateMgKgH = 0.0003m },
                    new InfusionRateRangeRecord { MinWeight = 60, MaxWeight = 70, InfusionRateMgKgH = 0.0004m },
                    new InfusionRateRangeRecord { MinWeight = 70, MaxWeight = 80, InfusionRateMgKgH = 0.0005m },
                    new InfusionRateRangeRecord { MinWeight = 80, MaxWeight = 90, InfusionRateMgKgH = 0.0006m },
                    new InfusionRateRangeRecord { MinWeight = 90, MaxWeight = 99, InfusionRateMgKgH = 0.0007m }
                ]
            }, {
                chemical3, [
                    new InfusionRateRangeRecord { MinWeight = 50, MaxWeight = 60, InfusionRateMgKgH = 0.0080m },
                    new InfusionRateRangeRecord { MinWeight = 60, MaxWeight = 70, InfusionRateMgKgH = 0.0085m },
                    new InfusionRateRangeRecord { MinWeight = 70, MaxWeight = 80, InfusionRateMgKgH = 0.0090m },
                    new InfusionRateRangeRecord { MinWeight = 80, MaxWeight = 90, InfusionRateMgKgH = 0.0095m },
                    new InfusionRateRangeRecord { MinWeight = 90, MaxWeight = 99, InfusionRateMgKgH = 0.0010m }
                ]
            }
        };

        var amountToAdministerMl =
            new Dictionary<int, decimal> { { 1, 50.0m }, { 2, 5.0m }, { 3, 10.0m } }; // in our clinic everyone gets the same amount (50.0 ml, 5.0ml and 10.0ml)

        PatientAppointmentRecords = [
            new PatientAppointmentRecord { PatientName = "John Doe", PatientWeightKg = 90.0m, MedicamentsToAdministerMl = amountToAdministerMl },
            new PatientAppointmentRecord { PatientName = "Jane Smith", PatientWeightKg = 60.0m, MedicamentsToAdministerMl = amountToAdministerMl },
            new PatientAppointmentRecord { PatientName = "Mike Doe", PatientWeightKg = 70.5m, MedicamentsToAdministerMl = amountToAdministerMl },
            new PatientAppointmentRecord { PatientName = "Mike Johnson", PatientWeightKg = 80.7m, MedicamentsToAdministerMl = amountToAdministerMl },
            new PatientAppointmentRecord { PatientName = "Sarah Johnson", PatientWeightKg = 75.3m, MedicamentsToAdministerMl = amountToAdministerMl },
            new PatientAppointmentRecord { PatientName = "Emily Johnson", PatientWeightKg = 68.9m, MedicamentsToAdministerMl = amountToAdministerMl }
        ];
    }

    [Benchmark(Baseline = true)]
    public int PrepareSchedulesReduced() {
        return PrepareSchedules(true).Count;
    }

    [Benchmark(Baseline = false)]
    public int PrepareSchedulesNonReduced() {
        return PrepareSchedules(false).Count;
    }

    private List<PatientSchedule> PrepareSchedules(bool reduceTerms) {
        var chemicals = LoadChemicals(reduceTerms);
        var patientAppointments = LoadPatientAppointments(chemicals, reduceTerms);
        var patientSchedules = new List<PatientSchedule>();

        foreach (var patientAppointment in patientAppointments) {
            var infusionOptions = new List<InfusionTask>();
            foreach (var keyValuePair in patientAppointment.MedicamentsToAdministerMl) {
                var solution = keyValuePair.Key;
                var amountRequiredMl = keyValuePair.Value;
                var infusionRate = GetInfusionRateForPatient(patientAppointment, chemicals[solution]);
                var infusionOption = CreateInfusionTask(patientAppointment.PatientName, patientAppointment.PatientWeightKg, solution, amountRequiredMl,
                    infusionRate.InfusionRateMgKgH);
                infusionOptions.Add(infusionOption);
            }

            patientSchedules.Add(new PatientSchedule {
                Tasks = infusionOptions,
                MinTaskDurationHours = infusionOptions.Select(x => x.DurationHours).Min(),
                MaxTaskDurationHours = infusionOptions.Select(x => x.DurationHours).Max()
            });
        }

        return patientSchedules;
    }


    private static InfusionTask CreateInfusionTask(string patientName, Fraction patientWeightKg, Medicine solution, Fraction amountToAdministerMl, Fraction infusionRateMgKgH) {
        var infusionRateMgH = infusionRateMgKgH * patientWeightKg; // with a typical infusion rate of 5.00 mg/kg/h this would something like 450 mg/h
        var infusionRateMlH = infusionRateMgH * solution.MassConcentrationMgMl.Reciprocal(); // this would be something like 22.50 ml/h or 45000 mh/h
        // var infusionRateMlH = infusionRateMgH / solution.MassConcentrationMgMl; // this would be something like 22.5000 ml/h or 45000.0 ml/h
        var scheduleItem = new InfusionTask {
            PatientName = patientName,
            Medicine = solution,
            InfusionRateMgKgH = infusionRateMgKgH,
            MassInfusionRateMgH = infusionRateMgH,
            VolumeInfusionRateMlH = infusionRateMlH,
            DurationHours = amountToAdministerMl / infusionRateMlH
        };
        return scheduleItem;
    }

    private static InfusionRateRange GetInfusionRateForPatient(PatientAppointment patientAppointment, List<InfusionRateRange> infusionRates) {
        return infusionRates.Find(range => range.MinWeight >= patientAppointment.PatientWeightKg && patientAppointment.PatientWeightKg < range.MaxWeight)!;
    }

    private Dictionary<Medicine, List<InfusionRateRange>> LoadChemicals(bool reduceTerms) {
        return MedicineRecords.ToDictionary(
            pair => new Medicine {
                Id = pair.Key.Id, Description = pair.Key.Description, MassConcentrationMgMl = Fraction.FromDecimal(pair.Key.MassConcentrationMgMl, reduceTerms)
            },
            pair => pair.Value.Select(infusionRate => new InfusionRateRange {
                InfusionRateMgKgH = Fraction.FromDecimal(infusionRate.InfusionRateMgKgH, reduceTerms),
                MinWeight = Fraction.FromDecimal(infusionRate.MinWeight, reduceTerms),
                MaxWeight = Fraction.FromDecimal(infusionRate.MaxWeight, reduceTerms)
            }).ToList());
    }

    private List<PatientAppointment> LoadPatientAppointments(Dictionary<Medicine, List<InfusionRateRange>> chemicals, bool reduceTerms) {
        var result = new List<PatientAppointment>();
        foreach (var patientRecord in PatientAppointmentRecords) {
            var patientAppointment = new PatientAppointment {
                PatientName = patientRecord.PatientName, PatientWeightKg = Fraction.FromDecimal(patientRecord.PatientWeightKg, reduceTerms), MedicamentsToAdministerMl = []
            };

            foreach (var chemical in chemicals.Keys) {
                if (patientRecord.MedicamentsToAdministerMl.TryGetValue(chemical.Id, out var amountRequiredMl)) {
                    patientAppointment.MedicamentsToAdministerMl[chemical] = Fraction.FromDecimal(amountRequiredMl, reduceTerms);
                }
            }

            result.Add(patientAppointment);
        }

        return result;
    }

    /// <summary>
    ///     The record as stored in database
    /// </summary>
    private class MedicineRecord {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal MassConcentrationMgMl { get; set; }

        // public decimal MassConcentrationPercent { get; set; }
    }

    /// <summary>
    ///     The loaded medicine expressing the mass concentration percent as a fraction
    /// </summary>
    private class Medicine {
        public int Id { get; set; }
        public string Description { get; set; }
        public Fraction MassConcentrationMgMl { get; set; }

        public override string ToString() {
            return $"{Description} ({MassConcentrationMgMl.ToDecimalWithTrailingZeros()} mg/ml)";
        }
    }

    /// <summary>
    ///     The configured infusion rates as stored in a database
    /// </summary>
    private class InfusionRateRangeRecord {
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal InfusionRateMgKgH { get; set; }
    }

    /// <summary>
    ///     The loaded infusion rates
    /// </summary>
    private class InfusionRateRange {
        public Fraction MinWeight { get; set; }
        public Fraction MaxWeight { get; set; }
        public Fraction InfusionRateMgKgH { get; set; }

        public override string ToString() {
            return $"{nameof(MinWeight)}: {MinWeight.ToDecimalWithTrailingZeros()}, " +
                   $"{nameof(MaxWeight)}: {MaxWeight.ToDecimalWithTrailingZeros()}, " +
                   $"{nameof(InfusionRateMgKgH)}: {InfusionRateMgKgH.ToDecimalWithTrailingZeros()}";
        }
    }

    /// <summary>
    ///     The patient data as stored in a database
    /// </summary>
    private class PatientAppointmentRecord {
        public string PatientName { get; set; }
        public decimal PatientWeightKg { get; set; }
        public Dictionary<int, decimal> MedicamentsToAdministerMl { get; set; }
    }

    /// <summary>
    ///     The patient information
    /// </summary>
    private class PatientAppointment {
        public string PatientName { get; set; }
        public Fraction PatientWeightKg { get; set; }
        public Dictionary<Medicine, Fraction> MedicamentsToAdministerMl { get; set; }

        public override string ToString() {
            return $"{nameof(PatientName)}: {PatientName}, " +
                   $"{nameof(PatientWeightKg)}: {PatientWeightKg.ToDecimalWithTrailingZeros()}";
        }
    }

    private class InfusionTask {
        public string PatientName { get; set; }
        public Medicine Medicine { get; set; }
        public Fraction InfusionRateMgKgH { get; set; }
        public Fraction MassInfusionRateMgH { get; set; }
        public Fraction VolumeInfusionRateMlH { get; set; }
        public Fraction DurationHours { get; set; }

        public override string ToString() {
            return
                $"{nameof(PatientName)}: {PatientName}, " +
                $"{nameof(Medicine)}: {Medicine}, " +
                $"{nameof(InfusionRateMgKgH)}: {InfusionRateMgKgH}, " +
                $"{nameof(MassInfusionRateMgH)}: {MassInfusionRateMgH.ToDecimalWithTrailingZeros()}, " +
                $"{nameof(VolumeInfusionRateMlH)}: {VolumeInfusionRateMlH.ToDecimalWithTrailingZeros()}, " +
                $"{nameof(DurationHours)}: {DurationHours.ToDecimalWithTrailingZeros()}";
        }
    }

    private class PatientSchedule {
        public List<InfusionTask> Tasks { get; set; }
        public Fraction MinTaskDurationHours { get; set; }
        public Fraction MaxTaskDurationHours { get; set; }

        public override string ToString() {
            return $"{nameof(Tasks)}: {Tasks.Count}, " +
                   $"{nameof(MinTaskDurationHours)}: {MinTaskDurationHours.ToDecimalWithTrailingZeros()}, " +
                   $"{nameof(MaxTaskDurationHours)}: {MaxTaskDurationHours.ToDecimalWithTrailingZeros()}";
        }
    }
}
