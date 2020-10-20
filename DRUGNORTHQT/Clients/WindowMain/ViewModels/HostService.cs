using System;
using System.Collections;
using System.IO;
using System.Reflection;
using BasicArrayProcessorSDK;
using System.Windows.Controls;

namespace HostViewer
{
    /// <summary>
    /// Object represents a plug-in manager.
    /// </summary>
    public class HostService : IHostProcessor
    {
        #region - field(s) -

        /// <summary>
        /// Initialize a collection to store all available plug-in.
        /// </summary>
        private Types.ArrayProcessorCollection mPlugInCollection = new Types.ArrayProcessorCollection();

        /// <summary>
        /// Control to display message from this host.
        /// </summary>
        private Label mLabel;

        #endregion

        #region - constructor(s) -

        /// <summary>
        /// Initialize this host with a message-sender.
        /// </summary>
        /// 
        /// <param name="control">host's message-sender.</param>
        public HostService(Label control)
        {
            mLabel = control;
        }

        #endregion

        #region - method(s) -

        #region - public member(s) -

        /// <summary>
        /// Finds all library(ies) in the plug-in folder.
        /// </summary>
        /// 
        /// <param name="folderPath">folder contains all plug-in library.</param>
        public void FindPlugIns(string folderPath)
        {
            //mPlugInCollection.Clear(); // reloads them all.

            // goes through all library-file(s) in the plug-in folder...
            DirectoryInfo container = new DirectoryInfo(folderPath);

            foreach (FileInfo file in container.GetFiles("*.dll"))
                this.LoadPlugIns(file.FullName);
        }

        /// <summary>
        /// Loads available plug-in(s) to this host.
        /// </summary>
        /// 
        /// <param name="filePath">path of plug-in library.</param>
        private void LoadPlugIns(string filePath)
        {
            Assembly pluginAssembly = Assembly.LoadFrom(filePath);

            object[] pluginAttributes;

            // loops through all the Types found in the assembly...

            var test = pluginAssembly.GetTypes();

            foreach (Type pluginType in pluginAssembly.GetTypes())
            {
                pluginAttributes = pluginType.GetCustomAttributes(typeof(ArrayProcessorPlugInAttribute), true);

                // only looks for a public, non-abstract and having attribute type(s).
                if (pluginType.IsPublic && !pluginType.IsAbstract && null != pluginAttributes)
                {
                    Type interfaceType = pluginType.GetInterface("BasicArrayProcessorSDK.IArrayProcessor", true);
                    if (null != interfaceType) // gets the right interface-type.
                    {
                        Types.AvailableArrayProcessor plugin = new Types.AvailableArrayProcessor();
                        plugin.AssemblyPath = filePath;
                        plugin.Instance = (IArrayProcessor)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
                        plugin.Instance.Attributes = pluginAttributes[0] as ArrayProcessorPlugInAttribute;
                        plugin.Instance.Initialize(this);

                        mPlugInCollection.Add(plugin); // loaded done.

                        plugin = null; // clean up...
                    }

                    interfaceType = null; // clean up...
                }
            }

            pluginAssembly = null; // clean up...
        }

        #endregion

        #region - implements IHostProcessor member(s) -

        public void Report(string message)
        {
            mLabel.Content = message;
        }

        public void Dispose()
        {
            foreach (Types.AvailableArrayProcessor plugin in mPlugInCollection)
            {
                plugin.Instance.Dispose();
                plugin.Instance = null;
            }

            mPlugInCollection.Clear();
        }

        #endregion

        #endregion

        #region - property(ies) -

        /// <summary>
        /// Gets the plug-in collection.
        /// </summary>
        public Types.ArrayProcessorCollection PlugIns
        {
            get { return mPlugInCollection; }
        }

        #endregion
    }

    namespace Types
    {
        /// <summary>
        /// Represents a plug-in collection.
        /// </summary>
        public class ArrayProcessorCollection : CollectionBase
        {
            #region - method(s) -

            /// <summary>
            /// Adds new plug-in to the collection.
            /// </summary>
            /// 
            /// <param name="plugin">new plug-in.</param>
            public void Add(AvailableArrayProcessor plugin)
            {
                this.List.Add(plugin);
            }

            /// <summary>
            /// Removes a plug-in from collection.
            /// </summary>
            /// 
            /// <param name="plugin">removing plug-in.</param>
            public void Remove(AvailableArrayProcessor plugin)
            {
                this.List.Remove(plugin);
            }

            ///// <summary>
            ///// Removes all plug-in from collection.
            ///// </summary>
            //public void Clear()
            //{
            //    this.List.Clear();
            //}

            #endregion

            #region - property(ies) -

            /// <summary>
            /// Gets numbre of available plug-in(s).
            /// </summary>
            public int PlugInCounter
            {
                get { return base.List.Count; }
            }

            #endregion
        }

        /// <summary>
        /// Represents an available plug-in.
        /// </summary>
        public class AvailableArrayProcessor
        {
            #region - field(s) -

            /// <summary>
            /// Plug-in instance.
            /// </summary>
            private IArrayProcessor mInstance;

            /// <summary>
            /// Assembly-path of plug-in.
            /// </summary>
            private string mAssemblyPath;

            #endregion

            #region - constructor(s) -

            /// <summary>
            /// Initialize a default instance.
            /// </summary>
            public AvailableArrayProcessor()
                : this(null, "")
            { }

            /// <summary>
            /// Initialize a instance with given value.
            /// </summary>
            /// 
            /// <param name="plugin">instance of a plug-in.</param>
            /// <param name="path">the path of plug-in assembly.</param>
            public AvailableArrayProcessor(IArrayProcessor plugin, string path)
            {
                mInstance = plugin;

                mAssemblyPath = path;
            }

            #endregion

            #region - property(ies) -

            /// <summary>
            /// Gets, sets the instance of plug-in.
            /// </summary>
            public IArrayProcessor Instance
            {
                get { return mInstance; }
                set { mInstance = value; }
            }

            /// <summary>
            /// Gets, sets the path of plug-in assembly.
            /// </summary>
            public string AssemblyPath
            {
                get { return mAssemblyPath; }
                set { mAssemblyPath = value; }
            }

            #endregion

            #region - method(s) -

            public override int GetHashCode()
            {
                int hashcode = 0;

                unchecked
                {
                    hashcode += 1000034 * mInstance.GetHashCode();
                }

                return hashcode;
            }

            public override bool Equals(object other)
            {
                if (null == other) return false;

                AvailableArrayProcessor anotherOne = other as AvailableArrayProcessor;

                return this.mInstance.Equals(anotherOne.mInstance);
            }

            public override string ToString()
            {
                return mInstance.ToString();
            }

            #endregion
        }
    }
}