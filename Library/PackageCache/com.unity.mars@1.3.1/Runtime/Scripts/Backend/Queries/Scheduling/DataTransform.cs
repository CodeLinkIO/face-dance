using System.Collections.Generic;

namespace Unity.MARS.Query
{
    /// <summary>
    /// A wrapper for everything needed to transform a given set of inputs into an output.
    /// Fulfills the same role as an IJob struct, but for managed data and functions.
    /// </summary>
    abstract class DataTransform
    {
        public List<int> WorkingIndices;

        public bool IsComplete { get; internal set; }

        internal bool NeedsCompletion { get; set; }

        internal int FrameBudget { get; set; }

        // unless this method is overriden, the default behavior for Tick() is simply to
        // complete all of the work synchronously.
        public virtual void Tick() { Complete(); }

        internal virtual void OnCycleStart() { }

        /// <summary>
        /// Force all remaining work to complete synchronously
        /// </summary>
        public abstract void ProcessAll();

        public void Complete()
        {
            NeedsCompletion = true;
            ProcessAll();
            IsComplete = true;
            NeedsCompletion = false;
        }
    }

    abstract class DataTransform<T1> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, ref T1 input);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, ref Input);
        }
    }

    abstract class DataTransform<T1, T2> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, ref T2 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Output;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, ref T3 output);

#pragma warning disable 649
        public ProcessDelegate Process;
        public T1 Input1;
        public T2 Input2;

        public T3 Output;
#pragma warning restore 649

        protected DataTransform(ProcessDelegate process)
        {
            Process = process;
        }

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3, T4> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, T3 in3, ref T4 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Input2;
        public T3 Input3;

        public T4 Output;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, Input3, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3, T4, T5> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, T3 in3, T4 in4, ref T5 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Input2;
        public T3 Input3;
        public T4 Input4;

        public T5 Output;
#pragma warning restore 649

        protected DataTransform(ProcessDelegate process)
        {
            Process = process;
        }

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, Input3, Input4, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3, T4, T5, T6> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, T3 in3, T4 in4, T5 in5, ref T6 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Input2;
        public T3 Input3;
        public T4 Input4;
        public T5 Input5;

        public T6 Output;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, Input3, Input4, Input5, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3, T4, T5, T6, T7> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, T3 in3, T4 in4, T5 in5, T6 in6,
            ref T7 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Input2;
        public T3 Input3;
        public T4 Input4;
        public T5 Input5;
        public T6 Input6;

        public T7 Output;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, Input3, Input4, Input5, Input6, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3, T4, T5, T6, T7, T8> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, T3 in3, T4 in4, T5 in5, T6 in6, T7 in7,
            ref T8 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Input2;
        public T3 Input3;
        public T4 Input4;
        public T5 Input5;
        public T6 Input6;
        public T7 Input7;

        public T8 Output;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, Input3, Input4, Input5, Input6, Input7, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3, T4, T5, T6, T7, T8, T9> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, T3 in3, T4 in4, T5 in5, T6 in6, T7 in7,
            T8 in8, ref T9 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Input2;
        public T3 Input3;
        public T4 Input4;
        public T5 Input5;
        public T6 Input6;
        public T7 Input7;
        public T8 Input8;

        public T9 Output;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, Input3, Input4, Input5, Input6, Input7, Input8, ref Output);
        }
    }

    abstract class DataTransform<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : DataTransform
    {
        public delegate void ProcessDelegate(List<int> indexes, T1 in1, T2 in2, T3 in3, T4 in4, T5 in5, T6 in6, T7 in7,
            T8 in8, T9 in9, ref T10 output);

#pragma warning disable 649
        public ProcessDelegate Process;

        public T1 Input1;
        public T2 Input2;
        public T3 Input3;
        public T4 Input4;
        public T5 Input5;
        public T6 Input6;
        public T7 Input7;
        public T8 Input8;
        public T9 Input9;

        public T10 Output;
#pragma warning restore 649

        protected DataTransform() { }

        public override void ProcessAll()
        {
            Process(WorkingIndices, Input1, Input2, Input3, Input4, Input5, Input6, Input7, Input8, Input9, ref Output);
        }
    }
}
